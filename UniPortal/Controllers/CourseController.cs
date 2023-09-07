using Microsoft.AspNetCore.Mvc;

namespace UniPortal.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
