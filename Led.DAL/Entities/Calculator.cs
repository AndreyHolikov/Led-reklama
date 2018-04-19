using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    public class Calculator
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        [Display(Name = "Template")]
        public string Template { get { return Name; } }

        [Display(Name = "Формула")]
        [Required]
        public string Formula { get; set; }

        public virtual ICollection<Display> Displays { get; set; }
        public virtual ICollection<OfferVideoProperty> OfferVideoPropertyies { get; set; }

        public Calculator()
        {
            Displays = new List<Display>();
            OfferVideoPropertyies = new List<OfferVideoProperty>();
        }
    }
}