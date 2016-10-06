using System;

namespace ProjectEuler.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class NoAttribute : Attribute
    {
        public int No { get; set; }

        public NoAttribute()
        {
        }

        public NoAttribute(int no)
        {
            No = no;
        }
    }
}