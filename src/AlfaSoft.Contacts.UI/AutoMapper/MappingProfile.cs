using AlfaSoft.Contacts.Business;
using AlfaSoft.Contacts.UI.Models;
using AutoMapper;

namespace AlfaSoft.Contacts.UI.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel, Contact>();
        }
    }
}
