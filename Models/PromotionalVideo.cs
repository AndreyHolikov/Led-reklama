using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.Models
{
    /// <summary>
    /// Рекламный ролик
    /// </summary>
    public class PromotionalVideo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Название")]
        [Required]
        public string Name { get; set; }

        [Required]
        public int AdvertiserId { get; set; }
        [Display (Name ="Рекламодатель")]
        [ForeignKey("AdvertiserId")]
        public Advertiser Advertiser { get; set; }

        [Display (Name = "Экраны")]
        public IEnumerable<LedDisplay> LedDisplays { get; set; }

        [Display (Name = "Характеристики")]
        public IEnumerable<PromotionalVideoProperty> Properties { get; set; }
    }
}