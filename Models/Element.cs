using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class Element
    {
        public string Name { get; private set; }
        public string Lable { get; private set; }
        public List<ElementRange> Ranges { get; private set; }

        public double Value { get; set; }

        public bool Enable { get; set; }

        #region ctor
        public Element(string name)
        {
            Name = name;
            Enable = false;
        }

        public Element(string name, List<ElementRange> ranges, string label)
        {
            Name = name;
            Ranges = ranges;
            Lable = label;
            Enable = true;
        }
        #endregion

        public void IfEnamble()
        {
            if (Enable)
            {
                return;
            }
            else
            {
                throw new Exception();
            }
        }

        public double GetResult()
        {
            IfEnamble();
                double result = 0;

                double cefficient = GetCoefficient();
                result = Value * cefficient;

                return result;
        }


        public double GetCoefficient()
        {
            IfEnamble();
            double coefficient = 0;
            foreach (ElementRange er in Ranges)
            {
                if ( (er.Min <= Value) & (Value <= er.Max) )
                {
                    coefficient = er.Coefficient;
                    break;
                }
            }

            return coefficient;
        }

        public int GetMin()
        {
            int min = 10000;
            foreach(ElementRange er in Ranges)
            {
                min = er.Min < min ? er.Min : min;
            }
            return min;
        }

        public int GetMax()
        {
            int max = 0;
            foreach (ElementRange er in Ranges)
            {
                max = er.Max > max ? er.Max : max;
            }
            return max;
        }
    }
}