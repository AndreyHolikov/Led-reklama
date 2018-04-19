using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.BLL.DTO
{
    public class DisplayDTO
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        //public Calculator Calculator { get; set; }

        //public virtual List<LedDisplayPropertyValue> LedDisplayPropertyValues { get; set; }
    }
}
