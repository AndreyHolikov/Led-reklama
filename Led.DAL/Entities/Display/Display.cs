using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    public class Display
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual int OwnerId { get; set; }
        [Display(Name = "Cобственник")]
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        [Required]
        public virtual int AddressId { get; set; }
        [Display(Name = "Адрес")]
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        public int? ImageId { get; set; }
        [Display(Name = "Картинка")]
        [ForeignKey("ImageId")]
        public Image Image { get; set; }

        public int? CalculatorId { get; set; }
        [Display(Name = "Калькулятор")]
        [ForeignKey("CalculatorId")]
        public Calculator Calculator { get; set; }

        // [Required]
        // public int LedDisplayPropertyValueId { get; set; }
        //// [Display(Name = "Характеристика")]
        // [ForeignKey("LedDisplayPropertyValueId")]
        // public LedDisplayPropertyValue LedDisplayPropertyValue { get; set; }
        public virtual List<LedDisplayPropertyValue> LedDisplayPropertyValues { get; set; }

        //public virtual ICollection<OfferVideoProperty> OfferVideoProperties { get; set; }

        

        public Display()
        {
            LedDisplayPropertyValues = new List<LedDisplayPropertyValue>();

            //OfferVideoProperties = new List<OfferVideoProperty>();
        }
    }
}