using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "Город")]
        [Required]
        public string Name { get; set; }
    }
}