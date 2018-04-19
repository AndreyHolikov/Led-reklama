using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    public class VideoPropertyInputRange
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OfferVideoPropertyId { get; set; }
        [Display(Name = "Характеристика")]
        [ForeignKey("OfferVideoPropertyId")]
        public OfferVideoProperty OfferVideoProperty { get; set; }

        [Display(Name = "Min")]
        [Required]
        public int Min { get; set; }

        [Display(Name = "Max")]
        [Required]
        public int Max { get; set; }

        [Display(Name = "Коэффициент")]
        public double Coefficient { get; set; }

        [NotMapped]
        public string StringFoHtml
        {
            get => $"от {Min} до {Max}";
            private set { }
        }

    }
}