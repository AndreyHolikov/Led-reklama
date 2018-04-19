using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.BLL.DTO
{
    /// <summary>
    /// Cобственник
    /// </summary>
    public class OwnerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DisplayDTO> Displays { get; set; } // virtual,
        public int CountLedDisplays { get; set; }

        public OwnerDTO()
        {
            Displays = new List<DisplayDTO>();
        }
    }
}