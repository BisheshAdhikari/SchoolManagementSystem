using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Grade(int id) {

            return View();
        
        }

        [HttpPost]
        public ActionResult CreateStudent(Grade model) {
            
            string result = model.SaveGrade();
            TempData["SuccessMessage"] = "Grade created successfully.";
            return RedirectToAction("Grade","Admin");
        
        
        }
    }
}
