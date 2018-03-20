using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Led.Models
{
    public class LedDisplay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }
        [Display(Name = "Cобственник")]
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        [Required]
        public int AddressId { get; set; }
        [Display (Name = "Адрес")]
        [Required]
        public Address Address { get; set; }



        public virtual ICollection<LedDisplayPropertyValue> LedDisplayPropertyValues { get; set; }

        public LedDisplay()
        {
            LedDisplayPropertyValues = new List<LedDisplayPropertyValue>();
        }
    }
}