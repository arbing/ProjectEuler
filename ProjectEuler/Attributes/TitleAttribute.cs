using System;

namespace ProjectEuler.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class TitleAttribute : Attribute
    {
        public string Title { get; set; }

        public TitleAttribute() : this(string.Empty)
        {
        }

        public TitleAttribute(string title)
        {
            Title = title;
        }
    }
}
