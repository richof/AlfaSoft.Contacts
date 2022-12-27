using AlfaSoft.Contacts.Business;
using AlfaSoft.Contacts.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlfaSoft.Contacts.UI.Controllers
{
    public class HomeController:Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public HomeController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _contactRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(contacts);
            return View(result);
        }

    }
}
