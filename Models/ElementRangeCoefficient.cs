using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class ElementRangeCoefficient
    {
        public int Id { get; set; }


        public int ElementRangeId { get; set; }

        public ElementRange ElementRange { get; set; }


        public int LedDisplayId { get; set; }

        public LedDisplay LedDisplay { get; set; }


        public double Coefficient { get; set; }
    }
}