using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Models
{
    public class DisplayViewModel
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }
    }
}