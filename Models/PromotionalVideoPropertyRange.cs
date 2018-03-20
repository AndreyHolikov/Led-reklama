using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class PromotionalVideoPropertyRange
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PromotionalVideoOfferPropertyId { get; set; }
        [Display (Name ="Характеристика")]
        [ForeignKey ("PromotionalVideoOfferPropertyId")]
        public PromotionalVideoOfferProperty PromotionalVideoOfferProperty { get; set; }

        [Display (Name = "Min")]
        [Required]
        public int Min { get; set; }

        [Display(Name = "Max")]
        [Required]
        public int Max { get; set; }

        public string StringFoHtml {
            get => $"от {Min} до {Max}"; 
            private set { }
        }

    }
}