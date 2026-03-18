using System.Text.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RmWebApi.Entities;

namespace RmWebApi.Context
{
    public class RmContext : IdentityDbContext<AppUser>
    {
        public RmContext(DbContextOptions<RmContext> db) : base(db) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>()
                .Property(p => p.Tags)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                );

            builder.Entity<Benefit>()
                .Property(p => p.ImageUrls)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                );

            builder.Entity<Service>()
                .Property(p => p.Images)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                );
        }

        public DbSet<HeroSettings> HeroSettings { get; set; }
        public DbSet<PageHero> PageHeroes { get; set; }

        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        public DbSet<GoogleReview> GoogleReviews { get; set; }

        public DbSet<StatFact> StatFacts { get; set; }

        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<BenefitCheckItem> BenefitCheckItems { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<LegalPage> LegalPages { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }

        public DbSet<FaqItem> FaqItems { get; set; }

        public DbSet<Contact>  Contacts { get; set; }
        public DbSet<ContactFormSubmission> ContactFormSubmissions { get; set; }

        public DbSet<ContentPage> ContentPages { get; set; }
    }
}