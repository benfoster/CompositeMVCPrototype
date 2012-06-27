using System;

namespace CompositeMVC.Application
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class WidgetDefinitionAttribute : Attribute
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public WidgetDefinitionAttribute(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}