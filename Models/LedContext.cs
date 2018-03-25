using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Led.Models
{
    public class LedContext: DbContext
    {
        public LedContext() :base("LedContext")
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<LedDisplay> LedDisplays { get; set; }
        public DbSet<PromotionalVideoOfferProperty> PromotionalVideoOfferProperties { get; set; }
        public DbSet<PromotionalVideoPropertyRange> PromotionalVideoPropertyRanges { get; set; }

        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<PromotionalVideo> PromotionalVideos { get; set; }
        public DbSet<PromotionalVideoProperty> PromotionalVideoProperties { get; set; }

        public DbSet<Image> Images { get; set; }
    }

    public class LedDbInitialaizer : DropCreateDatabaseAlways<LedContext>
    {
        class Range
        {
            public int Min { get; set; }
            public int Max { get; set; }
        }

        private void SeedPromotionalVideoPropertyRange(
            LedContext db, PromotionalVideoOfferProperty offerProperty, IEnumerable<Range> ranges)
        {
            ICollection<PromotionalVideoPropertyRange> propertyRanges = new List<PromotionalVideoPropertyRange>();
            foreach (Range range in ranges)
            {
                propertyRanges.Add(new PromotionalVideoPropertyRange()
                {
                    PromotionalVideoOfferProperty = offerProperty,
                    Min = range.Min,
                    Max = range.Max
                });
            };

            db.PromotionalVideoPropertyRanges.AddRange(propertyRanges);
        }

        protected override void Seed(LedContext db)
        {
            SeedDurations(db);
            SeedDurationPeriods(db);
            SeedNumberScreens(db);
            SeedNnumberOutputsIn6Min(db);

            City city1 = new City() { Name = "Могилев" };
            City city2 = new City() { Name = "Минск" };

            Address address1 = new Address() { FullAddress = "Минск, пр.Держинского", City = city2 };
            Address address2 = new Address() { FullAddress = "Минск, пр. Я.Купалы", City = city2 };
            Address address3 = new Address() { FullAddress = "Минск, пл. Независимости", City = city2 };

            Address address4 = new Address() { FullAddress = "Могилев, ТЦ Е-Сити", City = city1 };
            Address address5 = new Address() { FullAddress = "Могилев, пл.Островского", City = city1 };

            Address address6 = new Address() { FullAddress = "Минск, пл. Независимости", City = city2 };
            Address address7 = new Address() { FullAddress = "Минск, пл. Независимости", City = city2 };

            Owner mogilev_owner     = db.Owners.Add(new Owner { Name = "Могилев Led-Reklama" });
            Owner minsk_owner       = db.Owners.Add(new Owner { Name = "Minsk owner" });

            LedDisplay eCity_LedDisplay = db.LedDisplays.Add(new LedDisplay { Address = address4, Owner = mogilev_owner });
            LedDisplay preston_LedDisplay = db.LedDisplays.Add(new LedDisplay { Address = address5, Owner = mogilev_owner });

            db.LedDisplays.Add(new LedDisplay { Address = address1, Owner = minsk_owner, Image = new Image() { file_Name = "img1.jpg" } } );
            db.LedDisplays.Add(new LedDisplay { Address = address2, Owner = minsk_owner });
            db.LedDisplays.Add(new LedDisplay { Address = address3, Owner = minsk_owner });

            Advertiser green_Advertiser = db.Advertisers.Add(new Advertiser { Name = "ТЦ Green" });
            Advertiser mts_Advertiser = db.Advertisers.Add(new Advertiser { Name = "МТС" });

            PromotionalVideo green_Advertiser_ON_LedDisplay = db.PromotionalVideos.Add(new PromotionalVideo {
                Advertiser = green_Advertiser,
                Name = "Акции 15-31 Марта",
                LedDisplays = new LedDisplay[] { preston_LedDisplay }
            });

            PromotionalVideo mts_Advertiser_ON_LedDisplay = db.PromotionalVideos.Add(new PromotionalVideo {
                Advertiser = mts_Advertiser,
                Name = "Акции Марта",
                LedDisplays = new LedDisplay[] { eCity_LedDisplay, preston_LedDisplay }
            });


            //db.PromotionalVideoProperties.Add(
            //    new PromotionalVideoProperty {
            //        PromotionalVideo = green_Advertiser_ON_LedDisplay,
            //        PromotionalVideoOfferProperties = db.PromotionalVideoOfferProperties.Find(  ),
                    
            //    });

            base.Seed(db);
        }

        /// <summary>
        /// Продолжительность видео ролика
        /// </summary>
        private void SeedDurations(LedContext db)
        {
            PromotionalVideoOfferProperty offerProperty
                = db.PromotionalVideoOfferProperties.Add(
                new PromotionalVideoOfferProperty() {
                    Name = ElementsMapper.DURATION_VIDEO,
                    Label = "Продолжительность видео ролика",
                    UnitMeasure = "cек"
                });

            Range[] ranges = new Range[] { 
                new Range() { Min =1, Max = 10 },
                new Range() { Min = 11, Max = 20 },
                new Range() { Min = 21, Max = 30 }
            };

            SeedPromotionalVideoPropertyRange(db, offerProperty, ranges);
        }

        /// <summary>
        /// Время показа
        /// </summary>
        private void SeedDurationPeriods(LedContext db)
        {
            PromotionalVideoOfferProperty offerProperty
                = db.PromotionalVideoOfferProperties.Add(
                new PromotionalVideoOfferProperty()
                {
                    Name = ElementsMapper.DURATIO_PERIOD,
                    Label = "Период показа",
                    UnitMeasure = "день/дней"
                });

            Range[] ranges = new Range[] {
                new Range() { Min = 1, Max = 7 },
                new Range() { Min = 8, Max = 30 },
                new Range() { Min = 31, Max = 90 },
                new Range() { Min = 91, Max = 180 }
            };

            SeedPromotionalVideoPropertyRange(db, offerProperty, ranges);
        }

        /// <summary>
        /// Количество экранов
        /// </summary>
        private void SeedNumberScreens(LedContext db)
        {
            PromotionalVideoOfferProperty offerProperty
                = db.PromotionalVideoOfferProperties.Add(
                new PromotionalVideoOfferProperty()
                {
                    Name = ElementsMapper.NUMBER_SCREENS,
                    Label = "Количество экранов",
                    UnitMeasure = "шт"
                });

            Range[] ranges = new Range[] {
                new Range() { Min = 1, Max = 1 },
                new Range() { Min = 2, Max = 2 },
                new Range() { Min = 3, Max = 3 },
                new Range() { Min = 4, Max = 4 },
                new Range() { Min = 5, Max = 5 }
            };

            SeedPromotionalVideoPropertyRange(db, offerProperty, ranges);
        }

        /// <summary>
        /// Количество выходов в 6 мин
        /// </summary>
        private void SeedNnumberOutputsIn6Min(LedContext db)
        {
            PromotionalVideoOfferProperty offerProperty
                = db.PromotionalVideoOfferProperties.Add(
                new PromotionalVideoOfferProperty()
                {
                    Name = ElementsMapper.NUMBER_OUTPUTS_IN_6_MIN,
                    Label = "Количество выходов в 6 мин",
                    UnitMeasure = "раз в 6 мин"
                });

            Range[] ranges = new Range[] {
                new Range() { Min = 1, Max = 1 },
                new Range() { Min = 2, Max = 2 },
                new Range() { Min = 3, Max = 3 },
                new Range() { Min = 4, Max = 4 },
                new Range() { Min = 5, Max = 5 },
                new Range() { Min = 6, Max = 6 }
            };

            SeedPromotionalVideoPropertyRange(db, offerProperty, ranges);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().HasMany(c => c.Students)
        //        .WithMany(s => s.Courses)
        //        .Map(t => t.MapLeftKey("CourseId")
        //        .MapRightKey("StudentId")
        //        .ToTable("CourseStudent"));
        //}
    }
}