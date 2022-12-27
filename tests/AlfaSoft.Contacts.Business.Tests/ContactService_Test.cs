using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;

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
                ContactPhone="134321234",
                Email = "richar@mail.com"
            };
            mocker.GetMock<IContactRepository>()
                .Setup(r=>r.CreateAsync(contact))
                .ReturnsAsync(contact);
            ContactService service = mocker.CreateInstance<ContactService>();
            //Act
            Contact result = await service.CreateAsync(contact);
            //Assert
            result.ValidationResult.IsValid.Should().BeTrue();
            mocker.GetMock<IContactRepository>()
                .Verify(r=>r.CreateAsync(contact),Times.Once());
        }

        [Fact(DisplayName = "Must prevent to create an invalid contact")]
        [Trait("ContactService-Fact", "Validate contact")]
        public async Task CreateAsync_Contact_MustPreventToCreateAnInValidContact()
        {
            //Arrange
            Contact contact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = "Richar Flores",
                ContactPhone = "334321234",
                Email = "richar@mail"
            };
            mocker.GetMock<IContactRepository>()
                .Setup(r => r.CreateAsync(contact))
                .ReturnsAsync(contact);
            ContactService service = mocker.CreateInstance<ContactService>();
            //Act
            Contact result = await service.CreateAsync(contact);
            //Assert
            result.ValidationResult.IsValid.Should().BeFalse();
            mocker.GetMock<IContactRepository>()
                .Verify(r => r.CreateAsync(contact), Times.Never);
        }


       
    }
}