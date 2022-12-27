using AlfaSoft.Contacts.Business;
using AlfaSoft.Contacts.Business.Interfaces.Services;
using AlfaSoft.Contacts.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlfaSoft.Contacts.UI.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactsController(IContactService contactService, IMapper mapper, IContactRepository contactRepository)
        {
            _contactService = contactService;
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ContactViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var contact = _mapper.Map<ContactViewModel, Contact>(model);
            var result = await _contactService.CreateAsync(contact);
            if (!result.ValidationResult.IsValid)
            {

                foreach (var error in result.ValidationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);

            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var contact = await _contactRepository.GetAsync(id);
            var model = _mapper.Map<Contact, ContactViewModel>(contact);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ContactViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var contact = _mapper.Map<ContactViewModel, Contact>(model);
            var result = await _contactService.UpdateAsync(contact);
            if (!result.ValidationResult.IsValid)
            {

                foreach (var error in result.ValidationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var contact = await _contactRepository.GetAsync(id);
            var model = _mapper.Map<Contact, ContactViewModel>(contact);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var contact = await _contactRepository.GetAsync(id);
            var model = _mapper.Map<Contact, ContactViewModel>(contact);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(Guid id)
        {
            var result = await _contactService.DeleteAsync(id);
            if (result.ValidationResult !=null && !result.ValidationResult.IsValid)
            {

                foreach (var error in result.ValidationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                var model = _mapper.Map<Contact, ContactViewModel>(result);
                return RedirectToAction("Delete", model);

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
