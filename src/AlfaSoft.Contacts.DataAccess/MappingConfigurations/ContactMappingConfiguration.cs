using AlfaSoft.Contacts.Business;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AlfaSoft.Contacts.DataAccess.MappingConfigurations
{
    public class ContactMappingConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Email)
                .IsRequired();
            builder.Property(x => x.ContactPhone)
                .IsRequired();
            builder.Ignore(x=>x.ValidationResult);
            builder.Ignore(x=>x.CascadeMode);
            builder.Ignore(x => x.ClassLevelCascadeMode);
            builder.Ignore(x => x.RuleLevelCascadeMode);
            builder.ToTable("Contacts");
        }
    }
}
