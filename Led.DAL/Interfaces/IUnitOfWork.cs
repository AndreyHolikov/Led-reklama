using Led.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        
        IRepository<City> Cities { get; }
        IRepository<Address> Addresses { get; }
        
        IRepository<Display> Displays { get; }
        IRepository<LedDisplayProperty> LedDisplayProperties { get; }
        IRepository<LedDisplayPropertyValue> LedDisplayPropertyValues { get; }

        IRepository<OfferVideoProperty> OfferVideoProperties { get; }
        IRepository<VideoPropertyInputRange> VideoPropertyInputRanges { get; }
        IRepository<VideoPropertySelectOption> VideoPropertySelectOptions { get; }

        IRepository<Owner> Owners { get; }
        IRepository<Advertiser> Advertisers { get; }

        IRepository<PromotionalVideo> PromotionalVideos { get; }
        IRepository<PromotionalVideoProperty> PromotionalVideoProperties { get; }
        //IRepository<PromotionalVideoPropertyValue> PromotionalVideoPropertyValues { get; }

        IRepository<Image> Images { get; }

        IRepository<Calculator> Calculators { get; }

        void Save();
    }
}
