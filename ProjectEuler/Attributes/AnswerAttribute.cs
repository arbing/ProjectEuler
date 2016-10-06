using System;

namespace ProjectEuler.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class AnswerAttribute : Attribute
    {
        public string Answer { get; set; }

        public AnswerAttribute() : this(string.Empty)
        {
        }

        public AnswerAttribute(string answer)
        {
            Answer = answer;
        }

        public AnswerAttribute(long answer)
        {
            Answer = answer.ToString();
        }
    }
}