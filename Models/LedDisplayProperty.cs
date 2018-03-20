using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class LedDisplayProperty
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Название")]
        [Required]
        public string Name { get; set; }

        [Display(Name ="Label")]
        [Required]
        public string Lable { get; set; }


    }
}