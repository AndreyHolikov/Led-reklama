using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class PromotionalVideoOfferProperty
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "Название характеристики")]
        [Required]
        public string Name { get; set; }

        [Display (Name = "Label характеристики")]
        [Required]
        public string Label { get; set; }

        [Display (Name = "Единицы измерения")]
        public string UnitMeasure { get; set; }

        [Display (Name = "Диапазоны")]
        public IEnumerable<PromotionalVideoPropertyRange> Ranges { get; set; }

        public PromotionalVideoOfferProperty()
        {
            this.Ranges = new List<PromotionalVideoPropertyRange>();
        }
    }
}