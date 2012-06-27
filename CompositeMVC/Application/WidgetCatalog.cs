using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompositeMVC.Application
{
    public class WidgetCatalog : IWidgetCatalog
    {
        public IEnumerable<WidgetDefinition> GetWidgets()
        {
            foreach (var type in GetTypesWithAttribute<WidgetDefinitionAttribute>(Assembly.GetExecutingAssembly()))
            {
                yield return ReadWidgetDefinition(type);
            }
        }

        private static WidgetDefinition ReadWidgetDefinition(Type widgetType)
        {
            var definitionAttribute = (widgetType.GetCustomAttributes(typeof(WidgetDefinitionAttribute), false)
                                        .FirstOrDefault() as WidgetDefinitionAttribute);

            if (definitionAttribute != null)
            {
                return new WidgetDefinition { Id = definitionAttribute.Id, Name = widgetType.Name, WidgetType = widgetType };
            }

            return null;
        }

        private static IEnumerable<Type> GetTypesWithAttribute<TAttribute>(Assembly assembly) where TAttribute : Attribute
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(TAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}