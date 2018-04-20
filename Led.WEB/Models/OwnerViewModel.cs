using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Models
{
    public class OwnerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DisplayViewModel> LedDisplays { get; set; } // virtual,
        //public int CountLedDisplays { get; set; }

        public OwnerViewModel()
        {
            LedDisplays = new List<DisplayViewModel>();
        }
    }
}