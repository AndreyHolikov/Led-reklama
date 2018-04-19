using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Led.WEB.Models
{
    public class OfferVideoPropertyViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Подпись")]
        public string Label { get; set; }

        [Display(Name = "Единицы измерения")]
        public string UnitMeasure { get; set; }

        [Display(Name = "Min")]
        public int? Min { get; set; }

        [Display(Name = "Max")]
        public int? Max { get; set; }

        [Display(Name = "Default value")]
        public double DefaultValue { get; set; } = 1;

        [Display(Name = "Коэффициент")]
        public double Coefficient { get; set; } = 1;

        [Display(Name = "Показывать в калькуляторе")]
        public bool Visible { get; set; } = true;

        [Display(Name = "CSS class")]
        public string HtmlClass { get; set; }

        [Display(Name = "CSS class")]
        public string HtmlId { get; set; }

        public string RangeStringFoHtml
        {
            get => $"от {Min} до {Max}";
        }

        //[Display(Name = "Диапазоны")]
        //public ICollection<VideoPropertyInputRange> VideoPropertyInputRanges { get; set; }

        //[Display(Name = "SelectList")]
        //public ICollection<VideoPropertySelectOption> VideoPropertySelectOptions { get; set; }

        public OfferVideoPropertyViewModel()
        {
            //VideoPropertyInputRanges = new List<VideoPropertyInputRange>();
            //VideoPropertySelectOptions = new List<VideoPropertySelectOption>();
        }
    }
}