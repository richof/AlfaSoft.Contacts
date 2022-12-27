using AlfaSoft.Contacts.Business;
using AlfaSoft.Contacts.DataAccess.Context;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlfaSoft.Contacts.DataAccess.Tests
{
    public class ContactRepository_Test:BaseTest
    {

        [Fact(DisplayName = "Mus get a list of existing contacts")]
        [Trait("ContactRepository-Fact", "Return a list of Contacts")]
        public async Task GetAllAsync_Parameterless_MustReturnAListOfContacts()
        {
            using (var context = new MariaDbContext(options))
            {
                //Arrange
                Contact c1 = new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = "Alexander",
                    Email = "alex@mail.com",
                    ContactPhone = "232323234"
                };
                context.Contacts.Add(c1);
                Contact c2 = new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = "Barbara",
                    Email = "barbara@mail.com",
                    ContactPhone = "345232323"
                };
                context.Contacts.Add(c2);
                context.SaveChanges();
                ContactRepository repo = new ContactRepository(context);
                //Act
                IEnumerable<Contact> result = await repo.GetAllAsync();
                //Assert
                result.Count().Should().Be(2);
            }
        }

        [Fact(DisplayName = "Mus get a Contact passing the Id")]
        [Trait("ContactRepository-Fact", "Return a list of Contacts")]
        public async Task GetAsync_ContactId_MustReturnAContact()
        {
            using (var context = new MariaDbContext(options))
            {
                Guid c1Id = Guid.NewGuid();
                //Arrange
                Contact c1 = new Contact
                {
                    Id = c1Id,
                    Name = "Alexander",
                    Email = "alex@mail.com",
                    ContactPhone = "232323234"
                };
                context.Contacts.Add(c1);
                Contact c2 = new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = "Barbara",
                    Email = "barbara@mail.com",
                    ContactPhone = "345232323"
                };
                context.Contacts.Add(c2);
                context.SaveChanges();
                ContactRepository repo = new ContactRepository(context);
                //Act
                Contact result = await repo.GetAsync(c1Id);
                //Assert
                result.Name.Should().Be("Alexander");
            }
        }

        [Fact(DisplayName = "Must Add a contact into the context")]
        [Trait("ContactRepository-Fact", "Add a contact")]
        public async Task CreateAsync_Contact_MustAddAContact()
        {
            using (var context = new MariaDbContext(options))
            {
                //Arrange
                Contact newContact = new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = "Alexander",
                    Email = "alex@mail.com",
                    ContactPhone = "232323234"
                };
                ContactRepository repo = new ContactRepository(context);
                //Act
                Contact result= await repo.CreateAsync(newContact);
                //Assert
                context.Contacts.Count().Should().Be(1);
            }
        }
        //[Fact(DisplayName = "Must Update a contact ")]
        //[Trait("ContactRepository-Fact", "Update a contact")]
        //public async Task UpdateAsync_Contact_MustUpdateAContact()
        //{
        //    using (var context = new MariaDbContext(options))
        //    {
        //        //Arrange
        //        Contact contact = new Contact
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Alexander",
        //            Email = "alex@mail.com",
        //            ContactPhone = "232323234"
        //        };
        //        Contact newStateContact = new Contact
        //        {
        //            Id = contact.Id,
        //            Name = "Allisson",
        //            Email = "alex@mail.com",
        //            ContactPhone = "232323234"
        //        };
        //        context.Contacts.Attach(contact);
        //       // context.SaveChanges();
        //       // context.;
        //        ContactRepository repo = new ContactRepository(context);
        //        //Act
        //        Contact result = await repo.UpdateAsync(newStateContact);
        //        //Assert
        //        context.Contacts.FirstOrDefault().Name.Should().Be("Allisson");
        //    }
        //}
    }
}
