using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.BLL.DTO
{
    public class AddressDTO
    { 
        public int Id { get; set; }
        //public int CityId { get; set; }
        public string CityName { get; set; }
        public string FullAddress { get; set; }

        // public CityDTO City { get; set; }
    }
}
