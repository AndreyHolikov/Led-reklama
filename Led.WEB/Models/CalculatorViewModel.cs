using Led.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Models
{
    public class CalculatorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Template { get { return Name; } }
        public string Formula { get; set; }

        public virtual ICollection<DisplayViewModel> Displays { get; set; }
        public virtual ICollection<OfferVideoPropertyViewModel> OfferVideoProperties { get; set; }
    }
}