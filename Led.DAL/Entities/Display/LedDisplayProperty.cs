using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    public class LedDisplayProperty
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Название")]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<LedDisplayPropertyValue> LedDisplayPropertyValues { get; set; }

        public LedDisplayProperty()
        {
            LedDisplayPropertyValues = new List<LedDisplayPropertyValue>();
        }
    }
}