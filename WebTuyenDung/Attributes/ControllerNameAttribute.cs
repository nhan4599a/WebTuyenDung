using System;

namespace WebTuyenDung.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ControllerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
