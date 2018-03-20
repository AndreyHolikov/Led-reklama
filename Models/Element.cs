using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class Element
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public IList<ElementRange> Ranges { get; set; }
        public string UnitMeasure { get; set; }

        public double Value { get; set; }

        #region ctor
        public Element(string name, String label, IList<ElementRange> ranges, string unitMeasure = "")
        {
            Name = name;
            Label = label;
            Ranges = ranges;
            UnitMeasure = unitMeasure;
        }

        #endregion



        public double GetResult() => Value * GetCoefficient();


        public int GetMin() => Ranges.Min(x => x.Min); 

        public int GetMax() => Ranges.Max(x => x.Max);

        public double GetCoefficient()
        {
            //IfEnamble();
            ElementRange er = Ranges.First(x => (x.Min <= Value) & (Value <= x.Max));
            return er.ElementRangeCoefficient.Coefficient;
        }
    }
}