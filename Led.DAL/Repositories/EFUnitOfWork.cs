using Led.DAL.EF;
using Led.DAL.Entities;
using Led.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LedContext db;
        
        private AddressRepository addressRepository;
        private CityRepository cityRepository;

        private DisplayRepository displayRepository;
        private LedDisplayPropertyRepository ledDisplayPropertyRepository;
        private LedDisplayPropertyValueRepository ledDisplayPropertyValueRepository;

        private PromotionalVideoRepository promotionalVideoRepository;
        private PromotionalVideoPropertyRepository promotionalVideoPropertyRepository;
        //private PromotionalVideoPropertyValueRepository promotionalVideoPropertyValueRepository;

        private AdvertiserRepository advertiserRepository;
        private OwnerRepository ownerRepository;

        private OfferVideoPropertyRepository offerVideoPropertyRepository;
        private VideoPropertyHtmlTypeRepository videoPropertyHtmlTypeRepository;
        private VideoPropertyInputRangeRepository videoPropertyInputRangeRepository;
        private VideoPropertySelectOptionRepository videoPropertySelectOptionRepository;

        private CalculatorRepository calculatorRepository;

        private ImageRepository imageRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new LedContext(connectionString);
        }

        public IRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(db);
                return cityRepository;
            }
        }

        public IRepository<Address> Addresses
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new AddressRepository(db);
                return addressRepository;
            }
        }

        public IRepository<Display> Displays
        {
            get
            {
                if (displayRepository == null)
                    displayRepository = new DisplayRepository(db);
                return displayRepository;
            }
        }
        // LedDisplayPropertyRepositorys
        public IRepository<LedDisplayProperty> LedDisplayProperties
        {
            get
            {
                if (ledDisplayPropertyRepository == null)
                    ledDisplayPropertyRepository = new LedDisplayPropertyRepository(db);
                return ledDisplayPropertyRepository;
            }
        }

        // LedDisplayPropertyValueRepository ledDisplayPropertyValueRepository
        public IRepository<LedDisplayPropertyValue> LedDisplayPropertyValues
        {
            get
            {
                if (ledDisplayPropertyValueRepository == null)
                    ledDisplayPropertyValueRepository = new LedDisplayPropertyValueRepository(db);
                return ledDisplayPropertyValueRepository;
            }
        }

        // PromotionalVideoRepository promotionalVideoRepository;
        public IRepository<PromotionalVideo> PromotionalVideos
        {
            get
            {
                if (promotionalVideoRepository == null)
                    promotionalVideoRepository = new PromotionalVideoRepository(db);
                return promotionalVideoRepository;
            }
        }

        // PromotionalVideoPropertyRepository promotionalVideoPropertyRepository;
        public IRepository<PromotionalVideoProperty> PromotionalVideoProperties
        {
            get
            {
                if (promotionalVideoPropertyRepository == null)
                    promotionalVideoPropertyRepository = new PromotionalVideoPropertyRepository(db);
                return promotionalVideoPropertyRepository;
            }
        }

        // PromotionalVideoPropertyValueRepository promotionalVideoPropertyValueRepository;
        //public IRepository<PromotionalVideoPropertyValue> PromotionalVideoPropertyValues
        //{
        //    get
        //    {
        //        if (promotionalVideoPropertyValueRepository == null)
        //            promotionalVideoPropertyValueRepository = new PromotionalVideoPropertyValueRepository(db);
        //        return promotionalVideoPropertyValueRepository;
        //    }
        //}

        // AdvertiserRepository advertiserRepository;
        public IRepository<Advertiser> Advertisers
        {
            get
            {
                if (advertiserRepository == null)
                    advertiserRepository = new AdvertiserRepository(db);
                return advertiserRepository;
            }
        }

        // OwnerRepository ownerRepository;
        public IRepository<Owner> Owners
        {
            get
            {
                if (ownerRepository == null)
                    ownerRepository = new OwnerRepository(db);
                return ownerRepository;
            }
        }

        // OfferVideoPropertyRepository offerVideoPropertyRepository;
        public IRepository<OfferVideoProperty> OfferVideoProperties
        {
            get
            {
                if (offerVideoPropertyRepository == null)
                    offerVideoPropertyRepository = new OfferVideoPropertyRepository(db);
                return offerVideoPropertyRepository;
            }
        }

        // VideoPropertyHtmlTypeRepository videoPropertyHtmlTypeRepository;
        public IRepository<VideoPropertyHtmlType> VideoPropertyHtmlTypes
        {
            get
            {
                if (videoPropertyHtmlTypeRepository == null)
                    videoPropertyHtmlTypeRepository = new VideoPropertyHtmlTypeRepository(db);
                return videoPropertyHtmlTypeRepository;
            }
        }

        // VideoPropertyInputRangeRepository videoPropertyInputRangeRepository;
        public IRepository<VideoPropertyInputRange> VideoPropertyInputRanges
        {
            get
            {
                if (videoPropertyInputRangeRepository == null)
                    videoPropertyInputRangeRepository = new VideoPropertyInputRangeRepository(db);
                return videoPropertyInputRangeRepository;
            }
        }

        // VideoPropertySelectOptionRepository 
        public IRepository<VideoPropertySelectOption> VideoPropertySelectOptions
        {
            get
            {
                if (videoPropertySelectOptionRepository == null)
                    videoPropertySelectOptionRepository = new VideoPropertySelectOptionRepository(db);
                return videoPropertySelectOptionRepository;
            }
        }

        // CalculatorRepository calculatorRepository;
        public IRepository<Calculator> Calculators
        {
            get
            {
                if (calculatorRepository == null)
                    calculatorRepository = new CalculatorRepository(db);
                return calculatorRepository;
            }
        }

        // ImageRepository imageRepository;
        public IRepository<Image> Images
        {
            get
            {
                if (imageRepository == null)
                    imageRepository = new ImageRepository(db);
                return imageRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
