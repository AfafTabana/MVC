using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;
using MVC.Repository;

namespace MVC.Controllers
{
    public class CourseController : Controller
    {
       
       ICourseRepository crsRepo; 
       IDepartmentRepository departmentRepo;

        public CourseController(ICourseRepository courseRepository, IDepartmentRepository _departmentRepo)
        {
            crsRepo = courseRepository;
            departmentRepo = _departmentRepo;
        }

        public IActionResult SetSession(string name , int degree ) {

            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Degree", degree);
            return Content("Session Saved :)");
        
        }

        public IActionResult GetSession() {
            string name = HttpContext.Session.GetString("Name");
            int? degree = HttpContext.Session.GetInt32("Degree");
            return Content($"Name = {name} , Degree = {degree}"); 

        }
        public IActionResult Index()
        {
            List<Course> courses = crsRepo.GetAll();
            return View("Index" , courses);
        }

    
        public IActionResult Add()
        {
            CourseAddViewModel model = new CourseAddViewModel();
            List<Department> departmentList = departmentRepo.GetAll();
            model.detps = departmentList;

            return View("Add" , model);
        }


        [HttpPost]
        public IActionResult SaveAdd(CourseAddViewModel mymodel)
        {
            if (ModelState.IsValid == true)
            {
                Course course = new Course();
                course.Name = mymodel.Name;
                course.hours = mymodel.hours;
                course.degree = mymodel.degree;
                course.mindegree = mymodel.mindegree;
                course.DeptId = mymodel.DeptId; 

               crsRepo.Add(course);
               crsRepo.Save();

                return RedirectToAction ("Index");  
            }
            List<Department> departmentList = departmentRepo.GetAll();
            mymodel.detps = departmentList;
            return View("Add" , mymodel);
        }

        public IActionResult Greater(int mindegree , int degree)
        {
            if (mindegree < degree)
            {
                return Json(true);
            }else
            {
                return Json(false);
            }
        }
    }
}
