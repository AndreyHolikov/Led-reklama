using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class ElementRange
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public double Coefficient { get; private set; }
        public string StringForHtml { get; set; }

        public ElementRange(int min, int max, double coefficient, string stringForHtml)
        {
            Min = min;
            Max = max;
            Coefficient = coefficient;
        }
    }
}