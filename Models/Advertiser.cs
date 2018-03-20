using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Led.Models
{
    /// <summary>
    /// Рекламодатель
    /// </summary>
    public class Advertiser
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Название")]
        [Required]
        public string Name { get; set; }
        
        [Display(Name="Рекламные ролики")]
        public IEnumerable<PromotionalVideo> PromotionalVideos { get; set; }

        public Advertiser()
        {
            this.PromotionalVideos = new List<PromotionalVideo>();
        }
    }
}