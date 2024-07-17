using Backed_Developer_Project.Application.Model.FormDtos;
using Backed_Developer_Project.Application.Services.FormServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backed_Developer_Project.UI.Controllers
{
    //[Authorize]
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForm()
        {
            var allForm = await _formService.GetAll();

            return View(allForm);
        }

        [HttpGet]
        public async Task<IActionResult> AddForm()
        {
            var model = new AddFormDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddForm(AddFormDto newForm)
        {
            newForm.CreatedAt = DateTime.Now;
            await _formService.AddForm(newForm);
            return View(newForm);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
