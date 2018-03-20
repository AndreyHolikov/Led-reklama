using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class LedDisplayPropertyValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LedDisplayId { get; set; }
        [Display(Name ="Экран")]
        [ForeignKey("LedDisplayId")]
        public LedDisplay LedDisplay { get; set; }

        [Required]
        public int LedDisplayPropertyId { get; set; }
        [Display(Name = "Название свойства")]
        [ForeignKey("LedDisplayPropertyId")]
        public LedDisplayProperty LedDisplayProperty { get; set; }

        [Display(Name ="Значение")]
        [Required]
        public string Value { get; set; }
    }
}