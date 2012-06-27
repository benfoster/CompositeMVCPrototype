using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CompositeMVC.Application.Entities;

namespace CompositeMVC.Application
{
    public class PageBuilder : IPageBuilder
    {
        private readonly IWidgetCatalog widgetCatalog;
        private IDictionary<Type, Type> widgetBuilders;
        
        public PageBuilder(IWidgetCatalog widgetCatalog)
        {
            this.widgetCatalog = widgetCatalog;
        }
        
        public PageModel BuildPage(string id)
        {
            var page = GetPageEntity(id);

            var model = new PageModel
            {
                Id = page.Id,
                Title = page.Title,
                Slug = page.Slug
            };

            var widgetDefinitions = widgetCatalog.GetWidgets();

            // build widgets
            foreach (var pageWidget in page.Widgets)
            {
                // find definition 
                var widgetDefinition = widgetDefinitions.FirstOrDefault(x => x.Id == pageWidget.WidgetDefinitionId);

                if (widgetDefinition == null)
                    continue;

                var widget = BuildWidget(widgetDefinition, pageWidget);
                model.Widgets.Add(widget);
            }

            return model;
        }

        private IDictionary<Type, Type> Builders
        {
            get
            {
                if (widgetBuilders == null)
                {
                    widgetBuilders = (from t in Assembly.GetExecutingAssembly().GetTypes()
                                      from i in t.GetInterfaces()
                                      where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IWidgetBuilder<>)
                                      select new
                                      {
                                          BuilderType = t,
                                          WidgetType = i.GetGenericArguments()[0]
                                      })
                                     .ToDictionary(x => x.WidgetType, x => x.BuilderType);
                }

                return widgetBuilders;
            }
        }

        private Entities.Page GetPageEntity(string id)
        {
            // this will be loaded from repository
            var page = new Entities.Page
            {
                Id = id,
                Title = "Blog",
                Slug = "slug"                
            };

            // add widgets

            var postsWidget = new PageWidget
            {
                WidgetDefinitionId = "postswidget"
            };

            var videoWidget = new PageWidget
            {
                WidgetDefinitionId = "videowidget",
                Settings = new Dictionary<string, string> { 
                    { "title", "Brad Wilson - Microsoft's Modern Web Stack" },
                    { "url", "http://vimeo.com/43603472" }
                }
            };
            
            var twitterWidget = new PageWidget { 
                WidgetDefinitionId = "twitterwidget", 
                Settings = new Dictionary<string, string> { 
                    { "handle", "benfosterdev" } 
                } 
            };

            page.AddWidget(postsWidget);
            page.AddWidget(videoWidget);
            page.AddWidget(twitterWidget);           

            return page;
        }

        private IWidget BuildWidget(WidgetDefinition definition, PageWidget widgetInstance)
        {
            // look for an appropriate widget builder

            var builderType = GetWidgetBuilderType(definition.WidgetType);

            if (builderType != null)
            {
                dynamic builder = Activator.CreateInstance(builderType);
                return BuildWidget(builder, widgetInstance.Settings);
            }

            // no builder exists so just create manually
            var widget = Activator.CreateInstance(definition.WidgetType) as IWidget;
            widget.Settings = widgetInstance.Settings;
            return widget;
        }

        private T BuildWidget<T>(IWidgetBuilder<T> builder, IDictionary<string, string> settings) where T : IWidget
        {
            return builder.BuildWidget(settings);
        }

        private Type GetWidgetBuilderType(Type widgetType)
        {
            Type builder;
            Builders.TryGetValue(widgetType, out builder);
            return builder;
        }
    }
}