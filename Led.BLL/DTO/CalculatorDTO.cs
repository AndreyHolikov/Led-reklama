using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.BLL.DTO
{
    public class CalculatorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Template { get { return Name; } }
        public string Formula { get; set; }

        public virtual ICollection<DisplayDTO> Displays { get; set; }
        //public virtual ICollection<OfferVideoProperty> OfferVideoPropertyies { get; set; }
    }
}
