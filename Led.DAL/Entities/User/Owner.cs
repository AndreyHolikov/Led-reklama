     
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    /// <summary>
    /// Cобственник
    /// </summary>
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Экраны")]
        public ICollection<Display> LedDisplays { get; set; } // virtual,


        public Owner()
        {
            LedDisplays = new List<Display>();
        }

    }
}