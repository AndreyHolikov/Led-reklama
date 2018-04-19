using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PromotionalVideoProperty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PromotionVideoId  { get; set; }
        [Display (Name = "Рекламный ролик")]
        [ForeignKey ("PromotionVideoId")]
        public PromotionalVideo PromotionalVideo { get; set; }

        [Required]
        public int VideoOfferPropertyId { get; set; }
        [Display (Name ="Характеристика")]
        [ForeignKey ("VideoOfferPropertyId")]
        public OfferVideoProperty VideoOfferProperties { get; set; }

        [Display (Name = "Значение характеристики")]
        [Required]
        public double Value { get; set; }

        [Display (Name = "Коэффициент")]
        [Required]
        public double Coefficient { get; set; }
    }
}