using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlfaSoft.Contacts.Business.Tests
{
    public class ContactService_Test:BaseTest
    {

        [Fact(DisplayName = "Must create a valid contact")]
        [Trait("ContactService-Fact", "Create a Valid contact")]
        public async Task CreateAsync_Contact_MustCreateAValidContact()
        {
            //Arrange
            Contact contact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = "Richar Flores",
                Email = "richar@mail.com"
            };
            ContactService service = mocker.CreateInstance<ContactService>();
            //Act
            Contact result = await service.CreateAsync(contact);
            //Assert
            result.ValidationResult.IsValid.Should().BeTrue();
        }
    }
}