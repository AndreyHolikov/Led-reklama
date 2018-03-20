using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class ElementRange
    {
        public int Id { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }

        public int ElementRangeCoefficientId { get; set; }
        public ElementRangeCoefficient ElementRangeCoefficient { get; set; }

        public string StringForHtml {
            get { return $"от {Min} до {Max} "; }
            private set { }
        }

        public ElementRange( int min, int max, double coefficient, string stringForHtml)
        {
            this.Min = min;
            this.Max = max;
            this.ElementRangeCoefficient = new ElementRangeCoefficient() { Coefficient = coefficient };
            this.StringForHtml = stringForHtml;
        }
    }
}