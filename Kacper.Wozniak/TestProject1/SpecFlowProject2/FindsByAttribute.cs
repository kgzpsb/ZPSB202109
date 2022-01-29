using System;

namespace SpecFlowProject2
{
    internal class FindsByAttribute : Attribute
    {
        public string Using { get; set; }
        public object How { get; set; }
    }
}