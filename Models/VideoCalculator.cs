using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public static class ElementsMapper
    {
        public const string DURATION_VIDEO = "durationVideo";
        public const string DURATIO_PERIOD = "durationPeriod";
        public const string NUMBER_SCREENS = "numberScreens";
        public const string NUMBER_OUTPUTS_IN_6_MIN = "numberOutputsIn6Min";

        public static Dictionary<string, int> GetElements(
            string formula = "",
            int durationVideo = 25,
            int durationPeriod = 60,
            int numberScreens = 4,
            int numberOutputsIn6Min = 1)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>
            {
                { ElementsMapper.DURATION_VIDEO, durationVideo },
                { ElementsMapper.DURATIO_PERIOD, durationPeriod },
                { ElementsMapper.NUMBER_SCREENS, numberScreens },
                { ElementsMapper.NUMBER_OUTPUTS_IN_6_MIN, numberOutputsIn6Min }
            };
            return elements;
        }
    }

    public class VideoCalculator
    {
        #region
        //private const Char DELIMITER = ' ';
        //private Char[] ZNAK = new Char[] { '+', '-', '*', '/', '(', ')' };

        Dictionary<string, int> ValueElements;

        public string StringFormula { get; private set; }
        public double PriceOneSecond { get; private set; }
        public List<Element> Elements { get; set; }

        #endregion
        
        #region ctor
        public VideoCalculator( string formula, double priceOneSecond, Dictionary<string, int> valueElements)
        {
            this.StringFormula = formula;
            this.PriceOneSecond = priceOneSecond;
            this.ValueElements = valueElements;
            Initialaize();
        }

        private void Initialaize()
        {
            Elements = new List<Element>();

            InitializeDurations();
            InitializeDurationPeriods();
            InitializeNumberScreens();
            InitializeNnumberOutputsIn6Min();
        }

        // Продолжительность видео ролика
        private void InitializeDurations()
        {
            List<ElementRange> durationVideoRanges = new List<ElementRange>()
            {
                new ElementRange( min: 1, max: 10, coefficient: 1, stringForHtml: "от 1 до 10 сек" ),
                new ElementRange( min: 11, max: 20, coefficient: 0.9, stringForHtml: "от 11 до 20 сек" ),
                new ElementRange( min: 21, max: 30, coefficient: 0.8, stringForHtml: "от 21 до 30 сек" )
            };
            Element durationVideoElement = new Element(
                name: ElementsMapper.DURATION_VIDEO, 
                ranges: durationVideoRanges, 
                label: "Продолжительность видео ролика")
            {
                Value = ValueElements[ElementsMapper.DURATION_VIDEO]
            };
            Elements.Add(durationVideoElement);
        }

        // Время показа
        private void InitializeDurationPeriods()
        {
            List<ElementRange> durationPeriodRanges = new List<ElementRange>()
                {
                    new ElementRange( min: 1, max: 7, coefficient: 1, stringForHtml: "1 - 7 дней" ),
                    new ElementRange( min: 8, max: 30, coefficient: 0.9, stringForHtml: "8 - 30 дней" ),
                    new ElementRange( min: 31, max: 90, coefficient: 0.8, stringForHtml: "31 - 90 дней" ),
                    new ElementRange( min: 91, max: 180, coefficient: 0.7, stringForHtml: "91 - 180 дней" )
                };
            Element durationPeriodElement = new Element(
                name: ElementsMapper.DURATIO_PERIOD, 
                ranges: durationPeriodRanges, 
                label: "Период показа (дней)")
            {
                Value = ValueElements[ElementsMapper.DURATIO_PERIOD]
            };

            Elements.Add(durationPeriodElement);
        }

        // Количество экранов
        private void InitializeNumberScreens()
        {
            List<ElementRange> numberScreensRanges = new List<ElementRange>()
                {
                    new ElementRange( min: 1, max: 1, coefficient: 1, stringForHtml: "1 экран" ),
                    new ElementRange( min: 2, max: 2, coefficient: 0.95, stringForHtml: "2 экран" ),
                    new ElementRange( min: 3, max: 3, coefficient: 0.9, stringForHtml: "3 экран" ),
                    new ElementRange( min: 4, max: 4, coefficient: 0.85, stringForHtml: "4 экран" )
                };
            Element numberScreensElement = new Element(
                name: ElementsMapper.NUMBER_SCREENS, 
                ranges: numberScreensRanges, 
                label: "Количество экранов")
            {
                Value = ValueElements[ElementsMapper.NUMBER_SCREENS]
            };
            Elements.Add(numberScreensElement);
        }

        // Количество выходов в 6 мин
        private void InitializeNnumberOutputsIn6Min()
        {
            List<ElementRange> numberOutputsIn6MinRanges = new List<ElementRange>()
                {
                    new ElementRange( min: 1, max: 1, coefficient: 1, stringForHtml: "1 в 6 минут" ),
                    new ElementRange( min: 2, max: 2, coefficient: 1, stringForHtml: "2 в 6 минут" ),
                    new ElementRange( min: 3, max: 3, coefficient: 1, stringForHtml: "3 в 6 минут" ),
                    new ElementRange( min: 4, max: 4, coefficient: 1, stringForHtml: "4 в 6 минут" ),
                    new ElementRange( min: 5, max: 5, coefficient: 1, stringForHtml: "5 в 6 минут" ),
                    new ElementRange( min: 6, max: 6, coefficient: 1, stringForHtml: "6 в 6 минут" ),
                };
            Element numberOutputsIn6MinElement = new Element(
                name: ElementsMapper.NUMBER_OUTPUTS_IN_6_MIN, ranges: 
                numberOutputsIn6MinRanges, 
                label: "Количество выходов в 6 мин")
            {
                Value = ValueElements[ElementsMapper.NUMBER_OUTPUTS_IN_6_MIN]
            };
            Elements.Add(numberOutputsIn6MinElement);
        }
        #endregion

        public double Calculate()
        {
            double result = 0;

            // Делим строку на элементы
            //String[] substrings = StringFormula.Split(DELIMITER);

            // формула: priceOneSecond * sec

            double durationVideo = Elements.Find(x => x.Name.Contains(ElementsMapper.DURATION_VIDEO)).GetResult();
            double durationPeriod = Elements.Find(x => x.Name.Contains(ElementsMapper.DURATIO_PERIOD)).GetResult();
            double numberScreens = Elements.Find(x => x.Name.Contains(ElementsMapper.NUMBER_SCREENS)).GetResult();
            double numberOutputsIn6Min = Elements.Find(x => x.Name.Contains(ElementsMapper.NUMBER_OUTPUTS_IN_6_MIN)).GetResult();

            double durationVideoCoefficient = Elements.Find(x => x.Name.Contains(ElementsMapper.DURATION_VIDEO)).GetCoefficient();
            double durationPeriodCoefficient = Elements.Find(x => x.Name.Contains(ElementsMapper.DURATIO_PERIOD)).GetCoefficient();
            double numberScreensCoefficient = Elements.Find(x => x.Name.Contains(ElementsMapper.NUMBER_SCREENS)).GetCoefficient();
            double numberOutputsIn6MinCoefficient = Elements.Find(x => x.Name.Contains(ElementsMapper.NUMBER_OUTPUTS_IN_6_MIN)).GetCoefficient();


            result = PriceOneSecond * durationVideo;
            result = result * durationPeriod;
            result = result * numberScreens;
            result = result * numberOutputsIn6Min;

            return result;
        }
    }
}