using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backed_Developer_Project.UI.Controllers
{
    [Authorize]
    public class FormFieldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
