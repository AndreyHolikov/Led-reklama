using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Led.DAL.Entities;
using Led.DAL;
using Mapper = Led.DAL.VideoPropertyMapper;

namespace Led.DAL.EF
{
    public class LedDbInitializer :
    //    CreateDatabaseIfNotExists<LedContext>
     DropCreateDatabaseAlways<LedContext>
    //    DropCreateDatabaseIfModelChanges<LedContext>

    //https://metanit.com/sharp/entityframework/3.9.php

    //Если нам необходимо, чтобы при первом обращении база данных уже была заполнена некоторыми начальными значениями, то мы можем произвести ее инициализацию.
    //Инициализация происходит при первом обращении к контексту данных.
    //Для инициализации мы можем использовать один из классов инициализаторов, которые имеются в библиотеке.NET:
    //CreateDatabaseIfNotExists: инициализатор, используемый по умолчанию.Он не удаляет автоматчески базу данных и данные, а в случае изменения структуры моделей и контекста данных выбрасывает исключение.
    //DropCreateDatabaseIfModelChanges: данный инициализатор проверяет на соответствие моделям определения таблиц в базе данных.И если модели не соответствуют определению таблиц, то база данные пересоздается
    //DropCreateDatabaseAlways: этот инициализатор будет всегда пересоздавать базу данных.

    {
        class Range
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public double Coefficient { get; set; }
        }



        protected override void Seed(LedContext db)
        {
            //List<City> Cities = GetCities(db);
            //db.Cities.AddRange(Cities);

            City[] Cities = {
                db.Cities.Add(new City() { Name = "Могилев" }),
                db.Cities.Add(new City() { Name = "Минск" }) };

            //ICollection<Address> Addresses = GetAddresses(db);//, Cities);
            //db.Addresses.AddRange(Addresses);

            Address[] Addresses = {
                db.Addresses.Add(new Address() { FullAddress = "пр.Держинского", City = Cities[0] }),
                db.Addresses.Add(new Address() { FullAddress = "ул.Первомайская 34А", City = Cities[0] }),
                db.Addresses.Add(new Address() { FullAddress = "пл. Независимости 1", City = Cities[1] }),
                db.Addresses.Add(new Address() { FullAddress = "ул.Ленинская", City = Cities[0] }),
                db.Addresses.Add(new Address() { FullAddress = "ТЦ Е-Сити", City = Cities[0] }),
                db.Addresses.Add(new Address() { FullAddress = "пл.Островского", City = Cities[0] }),

                db.Addresses.Add(new Address() { FullAddress = "пл. Независимости 2", City = Cities[1] }),
                db.Addresses.Add(new Address() { FullAddress = "пл. Независимости 3", City = Cities[1] }) };

            //ICollection<Owner> Owners = GetOwners(db, Cities);
            //db.Owners.AddRange(Owners);

            Owner[] Owners = {
                db.Owners.Add(db.Owners.Add(new Owner { Name = "Led-Reklama.by(Могилев)" })),
                db.Owners.Add(db.Owners.Add(new Owner { Name = "Redstone.by(Минск)" })) };

            //ICollection<Image> Images = GetImages(db);
            //db.Images.AddRange(Images);

            Image[] Images = {
                db.Images.Add(new Image() { file_Name = "/images/magnit-1.jpg" }) };

            //ICollection<Display> Displays = GetDisplays(db);//, Owners, Addresses, Images);
            //db.Displays.AddRange(Displays);

            Display[] Displays = 
            {
               db.Displays.Add( new Display()
                {
                    Label = "Экран на Ленинской",
                    Name = "leninskaya",
                    Owner = Owners[0],
                    Address = Addresses[0],
                    Image = Images[0]
                }),

               db.Displays.Add( new Display()
                {
                    Label = "Экран на Первомайской",
                    Name = "pervomay",
                    Owner = Owners[0],
                    Address = Addresses[1],
                    Image = Images[0]
                })
            };

            ////LedDisplay eCity_LedDisplay = db.LedDisplays.Add(new LedDisplay { Address = address4, Owner = mogilev_owner });
            ////LedDisplay preston_LedDisplay = db.LedDisplays.Add(new LedDisplay { Address = address5, Owner = mogilev_owner });

            //ICollection<LedDisplayProperty> LedDisplayProperties = GetLedDisplayProperties(db);
            //db.LedDisplayProperties.AddRange(LedDisplayProperties);

            LedDisplayProperty[] LedDisplayProperties = 
            {
               db.LedDisplayProperties.Add( new LedDisplayProperty() { Name = "График работы" }),
               db.LedDisplayProperties.Add( new LedDisplayProperty() { Name = "Проходимость" }),
               db.LedDisplayProperties.Add( new LedDisplayProperty() { Name = "Габариты" }),
               db.LedDisplayProperties.Add( new LedDisplayProperty() { Name = "Контент" })
            };

            //ICollection<LedDisplayPropertyValue> LedDisplayPropertyValues = GetLedDisplayPropertyValues(db);//, Displays, LedDisplayProperties);
            //db.LedDisplayPropertyValues.AddRange(LedDisplayPropertyValues);

            LedDisplayPropertyValue[] LedDisplayPropertyValues = 
            {
            db.LedDisplayPropertyValues.Add( new LedDisplayPropertyValue()
                {
                    Display = Displays[0],
                    LedDisplayProperty = LedDisplayProperties[0],
                    Value = "9:00 -23:00",
                    //Displays = new List<Display>() { display_1, display_2 }
                }),
            db.LedDisplayPropertyValues.Add( new LedDisplayPropertyValue()
                {
                    Display = Displays[0],
                    LedDisplayProperty = LedDisplayProperties[1],
                    Value = "100 чел/час",
                    //Displays = new List<Display>() { display_1, display_2 }
                }),
            db.LedDisplayPropertyValues.Add(  new LedDisplayPropertyValue()
                {
                    Display = Displays[0],
                    LedDisplayProperty = LedDisplayProperties[2],
                    Value = "Габариты Габариты Габариты Габариты",
                    //Displays = new List<Display>() { display_1, display_2 }
                }),
            db.LedDisplayPropertyValues.Add(  new LedDisplayPropertyValue()
                {
                    Display = Displays[0],
                    LedDisplayProperty = LedDisplayProperties[3],
                    Value = "Видео, Аудио, Текст",
                    //Displays = new List<Display>() { display_1, display_2 }
                })
            };

            //ICollection<Advertiser> Advertisers = GetAdvertisers(db);
            //db.Advertisers.AddRange(Advertisers);

            Advertiser[] Advertisers =
            {
                db.Advertisers.Add(new Advertiser { Name = "ТЦ Green" }),
                db.Advertisers.Add(new Advertiser { Name = "МТС" })
            };

            //ICollection<PromotionalVideo> PromotionalVideos = GetPromotionalVideos(db);//, Advertisers, Displays);
            //db.PromotionalVideos.AddRange(PromotionalVideos);

            PromotionalVideo[] PromotionalVideos =
            {
               db.PromotionalVideos.Add( new PromotionalVideo
                {
                    Advertiser = Advertisers[0],
                    Name = "Акции 15-31 Марта",
                    Displays = new Display[] { Displays[0], }
                }),

               db.PromotionalVideos.Add( new PromotionalVideo
                {
                    Advertiser = Advertisers[1],
                    Name = "Акции Марта",
                    Displays = new Display[] { Displays[0], }
                })
            };

            ICollection<OfferVideoProperty> OfferVideoProperties = GetOfferVideoProperties(db);
            //db.OfferVideoProperties.AddRange(OfferVideoProperties);

            //ICollection<Calculator> Calculators = GetCalculators(db);//, Displays, OfferVideoProperties);
            //db.Calculators.AddRange(Calculators);

            Calculator[] Calculators =
            {
                db.Calculators.Add( new Calculator()
                {
                    Name = "Calc-1",
                    Formula = "Formula",
                    Displays = Displays ,
                    OfferVideoPropertyies = OfferVideoProperties
                })
            };

            ////db.LedDisplays.Add(new LedDisplay { Address = address1, Owner = minsk_owner, Image = img1 } );
            ////db.LedDisplays.Add(new LedDisplay { Address = address2, Owner = minsk_owner });
            ////db.LedDisplays.Add(new LedDisplay { Address = address3, Owner = minsk_owner });


            ////db.PromotionalVideoProperties.Add(
            ////    new PromotionalVideoProperty {
            ////        PromotionalVideo = green_Advertiser_ON_LedDisplay,
            ////        PromotionalVideoOfferProperties = db.PromotionalVideoOfferProperties.Find(  ),

            ////    });

            base.Seed(db);
        }

        /// <summary>
        /// Продолжительность видео ролика
        /// </summary>
        private OfferVideoProperty SeedPrice1Second(LedContext db)
        {
            OfferVideoProperty offerProperty
                = db.OfferVideoProperties.Add(
                new OfferVideoProperty()
                {
                    Name = Mapper.PRICE_1_SECOND,
                    Label = "Цена 1 секунды",
                    UnitMeasure = "руб.",
                    DefaultValue = 2,
                    Visible = false
                });
            return offerProperty;
        }


            /// <summary>
            /// Продолжительность видео ролика
            /// </summary>
            private OfferVideoProperty SeedDurations(LedContext db)
        {
            OfferVideoProperty offerProperty
                = db.OfferVideoProperties.Add(
                new OfferVideoProperty()
                {
                    Name = Mapper.DURATION_VIDEO,
                    Label = "Продолжительность видео ролика",
                    UnitMeasure = "cек",
                    Min = 1,
                    Max =30
                });

            Range[] ranges = new Range[] {
                new Range() { Min = 1, Max = 10, Coefficient = 0.1 },
                new Range() { Min = 11, Max = 20, Coefficient = 0.1 },
                new Range() { Min = 21, Max = 30, Coefficient = 0.2 }
            };

            SeedVideoPropertyInputRange(db, offerProperty, ranges);
            return offerProperty;
        }

        /// <summary>
        /// Время показа
        /// </summary>
        private OfferVideoProperty SeedDurationPeriods(LedContext db)
        {
            OfferVideoProperty offerProperty
                = db.OfferVideoProperties.Add(
                new OfferVideoProperty()
                {
                    Name = Mapper.DURATIO_PERIOD,
                    Label = "Период показа",
                    UnitMeasure = "день/дней",
                    Min = 1,
                    Max = 180
                });

            Range[] ranges = new Range[] {
                new Range() { Min = 1, Max = 7, Coefficient = 0.1 },
                new Range() { Min = 8, Max = 30, Coefficient = 0.2 },
                new Range() { Min = 31, Max = 90, Coefficient = 0.3 },
                new Range() { Min = 91, Max = 180, Coefficient = 0.4 }
            };

            SeedVideoPropertyInputRange(db, offerProperty, ranges);
            return offerProperty;
        }

        /// <summary>
        /// Количество экранов
        /// </summary>
        //private OfferVideoProperty SeedNumberScreens(LedContext db)
        //{
        //    OfferVideoProperty offerProperty
        //        = db.OfferVideoProperties.Add(
        //        new OfferVideoProperty()
        //        {
        //            Name = ElementsMapper.NUMBER_SCREENS,
        //            Label = "Количество экранов",
        //            UnitMeasure = "шт"
        //        });

        //    Range[] ranges = new Range[] {
        //        new Range() { Min = 1, Max = 1 },
        //        new Range() { Min = 2, Max = 2 },
        //        new Range() { Min = 3, Max = 3 },
        //        new Range() { Min = 4, Max = 4 },
        //        new Range() { Min = 5, Max = 5 }
        //    };

        //    SeedPromotionalVideoPropertyRange(db, offerProperty, ranges);
        //    return offerProperty;
        //}

        /// <summary>
        /// Количество выходов в 6 мин
        /// </summary>
        private OfferVideoProperty SeedNnumberOutputsIn6Min(LedContext db)
        {
            OfferVideoProperty offerProperty
                = db.OfferVideoProperties.Add(
                new OfferVideoProperty()
                {
                    Name = Mapper.NUMBER_OUTPUTS_IN_6_MIN,
                    Label = "Количество выходов в 6 мин",
                    UnitMeasure = "раз в 6 мин",
                    Min = 1,
                    Max = 6
                });

            Range[] ranges = new Range[] {
                new Range() { Min = 1, Max = 1, Coefficient = 1 },
                new Range() { Min = 2, Max = 2, Coefficient = 2 },
                new Range() { Min = 3, Max = 3, Coefficient = 3 },
                new Range() { Min = 4, Max = 4, Coefficient = 4 },
                new Range() { Min = 5, Max = 5, Coefficient = 5 },
                new Range() { Min = 6, Max = 6, Coefficient = 6 }
            };

            SeedVideoPropertyInputRange(db, offerProperty, ranges);
            return offerProperty;
        }


        private void SeedVideoPropertyInputRange(
            LedContext db, OfferVideoProperty offerProperty, IEnumerable<Range> ranges)
        {
            ICollection<VideoPropertyInputRange> propertyRanges = new List<VideoPropertyInputRange>();
            foreach (Range range in ranges)
            {
                //offerProperty.Min = range.Min;
                //offerProperty.Max = range.Max;
                propertyRanges.Add(new VideoPropertyInputRange()
                {
                    OfferVideoProperty = offerProperty,
                    Min = range.Min,
                    Max = range.Max
                });
            };

            db.VideoPropertyInputRanges.AddRange(propertyRanges);
        }

        private void SeedVideoPropertySelectOption(
            LedContext db, OfferVideoProperty offerProperty, IEnumerable<Range> ranges)
        {
            ICollection<VideoPropertyInputRange> propertyRanges = new List<VideoPropertyInputRange>();
            foreach (Range range in ranges)
            {
                //offerProperty.Min = range.Min;
                //offerProperty.Max = range.Max;
                propertyRanges.Add(new VideoPropertyInputRange()
                {
                    OfferVideoProperty = offerProperty,
                    Min = range.Min,
                    Max = range.Max
                });
            };

            db.VideoPropertyInputRanges.AddRange(propertyRanges);
        }

        private List<City> GetCities(LedContext db)
        {
            List<City> ResultCollection = new List<City>()
            {
                //db.Cities.Add(new City() { Name = "Могилев", Namep="1" }),
                //db.Cities.Add(new City() { Name = "Минск" })
            };
            return ResultCollection;
        }

        private ICollection<Address> GetAddresses(LedContext db)
        {
            ICollection<Address> ResultCollection = new List<Address>()
            {
                //db.Addresses.Add(new Address() { FullAddress = "пр.Держинского", City = db.Cities.FirstOrDefault( c=>c.Name == "Могилев") }),
                //db.Addresses.Add(new Address() { FullAddress = "ул.Первомайская 34А", City = db.Cities.FirstOrDefault( c=>c.Name == "Могилев") }),
                //db.Addresses.Add(new Address() { FullAddress = "пл. Независимости", City = db.Cities.FirstOrDefault( c=>c.Name == "Минск") }),
                //db.Addresses.Add(new Address() { FullAddress = "ул.Ленинская", City = db.Cities.FirstOrDefault( c=>c.Name == "Могилев") }),
                //db.Addresses.Add(new Address() { FullAddress = "ТЦ Е-Сити", City = db.Cities.FirstOrDefault( c=>c.Name == "Могилев") }),
                //db.Addresses.Add(new Address() { FullAddress = "пл.Островского", City = db.Cities.FirstOrDefault( c=>c.Name == "Могилев") }),

                //db.Addresses.Add(new Address() { FullAddress = "пл. Независимости", City = db.Cities.FirstOrDefault( c=>c.Name == "Минск") }),
                //db.Addresses.Add(new Address() { FullAddress = "пл. Независимости", City = db.Cities.FirstOrDefault( c=>c.Name == "Минск") }),
            };
            return ResultCollection;
        }

        private ICollection<Owner> GetOwners(LedContext db, List<City> Cities)
        {
            ICollection<Owner> ResultCollection = new List<Owner>()
            {
                //db.Owners.Add(new Owner { Name = "Led-Reklama.by(Могилев)" }),
                //db.Owners.Add(new Owner { Name = "Redstone.by(Минск)" })
            };
            return ResultCollection;
        }

        private ICollection<Image> GetImages(LedContext db)
        {
            List<Image> ResultCollection = new List<Image>()
            {
                //db.Images.Add(new Image() { file_Name = "/images/magnit-1.jpg" })
            };
            return ResultCollection;
        }

        private ICollection<Display> GetDisplays(LedContext db)
        {
            List<Display> Displays = new List<Display>()
            {
               //db.Displays.Add( new Display()
               // {
               //     Label = "Экран на Ленинской",
               //     Name = "leninskaya",
               //     Owner = db.Owners.FirstOrDefault(o=>o.Name == "Led-Reklama.by(Могилев)"),
               //     Address = db.Addresses.FirstOrDefault( a => a.FullAddress == "ул.Ленинская"),
               //     Image = db.Images.FirstOrDefault(o=>o.file_Name == "/images/magnit-1.jpg")
               // }),

               //db.Displays.Add( new Display()
               // {
               //     Label = "Экран на Первомайской",
               //     Name = "pervomay",
               //     Owner = db.Owners.FirstOrDefault(o => o.Name == "Led-Reklama.by(Могилев)"),
               //     Address = db.Addresses.FirstOrDefault(a => a.FullAddress == "ул.Первомайская 34А"),
               //     Image = db.Images.FirstOrDefault(o=>o.file_Name == "/images/magnit-1.jpg")
               // })
            };
            return Displays;
        }


        private ICollection<LedDisplayProperty> GetLedDisplayProperties(LedContext db)
        {
            List<LedDisplayProperty> ResultCollection = new List<LedDisplayProperty>()
            {
               //db.LedDisplayProperties.Add( new LedDisplayProperty() { Name = "График работы" }),
               //db.LedDisplayProperties.Add( new LedDisplayProperty() { Name = "Проходимость" }),
               //db.LedDisplayProperties.Add( new LedDisplayProperty() { Name = "Габариты" }),
               //db.LedDisplayProperties.Add( new LedDisplayProperty() { Name = "Контент" })
            };
            return ResultCollection;
        }

        private ICollection<LedDisplayPropertyValue> GetLedDisplayPropertyValues(LedContext db)
            //ICollection<Display> Displays, ICollection<LedDisplayProperty> LedDisplayProperties)
        {
            List<LedDisplayPropertyValue> ResultCollection = new List<LedDisplayPropertyValue>()
            {
            //db.LedDisplayPropertyValues.Add( new LedDisplayPropertyValue()
            //    {
            //        Display = db.Displays.FirstOrDefault(d => d.Name == "Экран на Ленинской"),
            //        LedDisplayProperty = db.LedDisplayProperties.FirstOrDefault(l=>l.Name == "График работы"),
            //        Value = "9:00 -23:00",
            //        //Displays = new List<Display>() { display_1, display_2 }
            //    }),
            //db.LedDisplayPropertyValues.Add( new LedDisplayPropertyValue()
            //    {
            //        Display = db.Displays.FirstOrDefault(d => d.Name == "Экран на Ленинской"),
            //        LedDisplayProperty = db.LedDisplayProperties.FirstOrDefault(l=>l.Name == "Проходимость"),
            //        Value = "100 чел/час",
            //        //Displays = new List<Display>() { display_1, display_2 }
            //    }),
            //db.LedDisplayPropertyValues.Add(  new LedDisplayPropertyValue()
            //    {
            //        Display = db.Displays.FirstOrDefault(d => d.Name == "Экран на Ленинской"),
            //        LedDisplayProperty = db.LedDisplayProperties.FirstOrDefault(l=>l.Name == "Габариты"),
            //        Value = "Габариты Габариты Габариты Габариты",
            //        //Displays = new List<Display>() { display_1, display_2 }
            //    }),
            //db.LedDisplayPropertyValues.Add(  new LedDisplayPropertyValue()
            //    {
            //        Display = db.Displays.FirstOrDefault(d => d.Name == "Экран на Ленинской"),
            //        LedDisplayProperty = db.LedDisplayProperties.FirstOrDefault(l=>l.Name == "Контент"),
            //        Value = "Видео, Аудио, Текст",
            //        //Displays = new List<Display>() { display_1, display_2 }
            //    })
            };
            return ResultCollection;
        }

        private ICollection<Advertiser> GetAdvertisers(LedContext db)
        {
            List<Advertiser> ResultCollection = new List<Advertiser>()
            {
                //db.Advertisers.Add(new Advertiser { Name = "ТЦ Green" }),
                //db.Advertisers.Add(new Advertiser { Name = "МТС" })
            };
            return ResultCollection;
        }

        private ICollection<PromotionalVideo> GetPromotionalVideos(LedContext db)//, ICollection<Advertiser> Advertisers, ICollection<Display> Displays)
        {
            List<PromotionalVideo> ResultCollection = new List<PromotionalVideo>()
            {
               //db.PromotionalVideos.Add( new PromotionalVideo
               // {
               //     Advertiser = db.Advertisers.FirstOrDefault(a=>a.Name ==  "ТЦ Green" ),
               //     Name = "Акции 15-31 Марта",
               //     Displays = new Display[] { db.Displays.FirstOrDefault(d => d.Name == "Экран на Ленинской"), }
               // }),

               //db.PromotionalVideos.Add( new PromotionalVideo
               // {
               //     Advertiser = db.Advertisers.FirstOrDefault(a=>a.Name ==  "МТС" ),
               //     Name = "Акции Марта",
               //     Displays = new Display[] { db.Displays.FirstOrDefault(d => d.Name == "Экран на Ленинской"), }
               // })
            };
            return ResultCollection;
        }

        private ICollection<OfferVideoProperty> GetOfferVideoProperties(LedContext db)
        {
            ICollection<OfferVideoProperty> OfferVideoProperties = new List<OfferVideoProperty>();
            OfferVideoProperties.Add(SeedPrice1Second(db));
            OfferVideoProperties.Add(SeedDurations(db));
            OfferVideoProperties.Add(SeedDurationPeriods(db));
            //OfferVideoProperties.Add(SeedNumberScreens(db));
            OfferVideoProperties.Add(SeedNnumberOutputsIn6Min(db));

            return OfferVideoProperties;
        }

        private ICollection<Calculator> GetCalculators(LedContext db)//, ICollection<Display> Displays, ICollection<OfferVideoProperty> OfferVideoProperties)
        {
            List<Calculator> ResultCollection = new List<Calculator>()
            {
                //db.Calculators.Add( new Calculator()
                //{
                //    Name = "Calc-1",
                //    Formula = "Formula",
                //    Displays = db.Displays.ToList() ,
                //    OfferVideoPropertyies = db.OfferVideoProperties.ToList()
                //})
            };
            return ResultCollection;
        }
    }
}