using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    public class LedDisplayPropertyValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DisplayId { get; set; }
        [Display(Name = "Экран")]
        [ForeignKey("DisplayId")]
        public Display Display { get; set; }

        [Required]
        public int LedDisplayPropertyId { get; set; }
        [Display(Name = "Название свойства")]
        [ForeignKey("LedDisplayPropertyId")]
        public LedDisplayProperty LedDisplayProperty { get; set; }

        [Display(Name ="Значение")]
        [Required]
        public string Value { get; set; }

        //public virtual ICollection<Display> Displays { get; set; }

        public LedDisplayPropertyValue()
        {
            //Displays = new List<Display>();
        }
    }
}