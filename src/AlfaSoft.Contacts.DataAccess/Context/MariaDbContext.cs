using AlfaSoft.Contacts.Business;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;


namespace AlfaSoft.Contacts.DataAccess.Context
{
    public class MariaDbContext : DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore(typeof(ValidationResult));
            modelBuilder.Ignore(typeof(CascadeMode));            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MariaDbContext).Assembly);

            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = Guid.NewGuid(),
                Name = "Ozzy Orbourne",
                Email = "ozzy@devil.com",
                ContactPhone = "234321234"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                Name = "David Bowie",
                Email = "david@spidersfrommars.com",
                ContactPhone = "343234546"
            });
            
        }

    }
}
