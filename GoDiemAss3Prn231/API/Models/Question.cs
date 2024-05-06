using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Question
    {
        public string? Content { get; set; }
        public string? A { get; set; }
        public string? B { get; set; }
        public string? C { get; set; }
        public string? D { get; set; }
        public string? Answer { get; set; }
    }
}
