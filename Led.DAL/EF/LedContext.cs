using Led.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Led.DAL.EF
{
    public class LedContext : DbContext
    {

        static LedContext()
        {
            Database.SetInitializer<LedContext>(new LedDbInitializer()); 
        }
        public LedContext(string connectionString = "LedContextLocalhost")
            : base(connectionString)
        {
        }

        public DbSet<Display> Displays { get; set; }
        public DbSet<LedDisplayProperty> LedDisplayProperties { get; set; }
        public DbSet<LedDisplayPropertyValue> LedDisplayPropertyValues { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Owner> Owners { get; set; }

       // public DbSet<LedDisplay> LedDisplays { get; set; }
        public DbSet<OfferVideoProperty> OfferVideoProperties { get; set; }
        public DbSet<VideoPropertyHtmlType> VideoPropertyHtmlTypes { get; set; }
        public DbSet<VideoPropertyInputRange> VideoPropertyInputRanges { get; set; }
        public DbSet<VideoPropertySelectOption> VideoPropertySelectOptions { get; set; }


        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<PromotionalVideo> PromotionalVideos { get; set; }
        public DbSet<PromotionalVideoProperty> PromotionalVideoProperties { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Calculator> Calculators { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //// переопределение добавления
            //modelBuilder.Entity<City>()
            //    .MapToStoredProcedures(b => b.Insert(sp => sp.HasName("InsertCity")
            //        .Parameter(pm => pm.Name, "Name")
            //        .Result(rs => rs.Id, "Id")));

            //// переопределение обновления
            //modelBuilder.Entity<City>()
            //    .MapToStoredProcedures(b => b.Update(sp => sp.HasName("UpdateCity")
            //        .Parameter(pm => pm.Name, "Name")
            //        .Parameter(pm => pm.Id, "Id")));

            //// переопределение удаления
            //modelBuilder.Entity<City>()
            //    .MapToStoredProcedures(b => b.Delete(sp => sp.HasName("DeleteCity")
            //        .Parameter(pm => pm.Id, "Id")));

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Display>().HasMany(c => c.OfferVideoProperties)
            //    .WithMany(s => s.Displays)
            //    .Map(t => t.MapLeftKey("DisplayId")
            //    .MapRightKey("OfferVideoPropertyId")
            //    .ToTable("DisplayOfferVideoProperty"));

            // https://metanit.com/sharp/entityframework/6.4.php
            //modelBuilder.ComplexType<PhoneInfo>();
            //base.OnModelCreating(modelBuilder);
        }


    }

    
}