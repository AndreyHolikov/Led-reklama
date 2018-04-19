using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    public class VideoPropertySelectOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OfferVideoPropertyId { get; set; }
        [Display(Name = "Характеристика")]
        [ForeignKey("OfferVideoPropertyId")]
        public OfferVideoProperty OfferVideoProperty { get; set; }

        [Display(Name = "Подпись")]
        [Required]
        public string Text { get; set; }

        [Display(Name = "Значение")]
        [Required]
        public string Value { get; set; }

        [Display(Name = "Коэффициент")]
        public double? Coefficient { get; set; }

    }
}