using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CityId { get; set; }
        [Display ( Name = "Город")]
        [ForeignKey("CityId")]
        public City City { get; set; }

        [Display (Name ="Полный адрес")]
        [Required]
        public string FullAddress { get; set; }
    }
}