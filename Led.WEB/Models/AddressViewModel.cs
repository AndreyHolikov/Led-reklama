using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        //public int CityId { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
    }
}