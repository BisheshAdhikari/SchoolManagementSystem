using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Models;
using System.Collections.Generic;
using System.Reflection;

namespace School_Management_System.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region "Login"
        public ActionResult Login() {


            return View();
        
        
        
        }
        [HttpPost]
        public ActionResult SaveLogin(Login model)
        {
            string resukt =model.SaveLogin();

            return View();



        }

        #endregion

        #region"Student"

        public ActionResult StudentRegistration() {
            
           Student student = new Student();
            List<Grade> gradelist = student.GetGradesList();
            IEnumerable<object> en = gradelist;
            List<SelectListItem> gradeItems = new List<SelectListItem>();
            foreach (var item in en)
            {
                Grade grade = (Grade)item;
                gradeItems.Add(new SelectListItem { Value = grade.GradeId.ToString(), Text = grade.GradeName });
            }

            ViewBag.Grades = gradeItems;


            return View();
        
        }


        public ActionResult StudentList() {
            Student student = new Student();
            List<Student> students = student.GetStudentList();

            return View(students);
        
        }

        [HttpPost]  
        public ActionResult SaveStudent(Student model) {

            model.SaveStudent();
            return RedirectToAction("StudentRegistration","Profile");
        } 

        #endregion
    }
}
