using AlfaSoft.Contacts.Business;
using AlfaSoft.Contacts.Business.Interfaces.Services;
using AlfaSoft.Contacts.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlfaSoft.Contacts.UI.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ContactViewModel model)
        {
            if(!ModelState.IsValid) return View(model);
            var contact = _mapper.Map<ContactViewModel, Contact>(model);
            var result = await _contactService.CreateAsync(contact);
            if (!result.ValidationResult.IsValid) { 

                foreach (var error in result.ValidationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
