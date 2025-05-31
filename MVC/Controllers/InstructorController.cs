using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVC.Models;
using MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Hosting;


namespace MVC.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public InstructorController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        ITIContext context = new ITIContext();

        /*
        public IActionResult Index()
        {
            List<Instructor> inst = context.Instructors.ToList();
    
            return View("Index", inst);
        }*/

        public IActionResult Details(int id)
        {
            Instructor inst = context.Instructors.FirstOrDefault(e => e.Id == id);
            if (inst != null)
            {
                return View("Details", inst);
            }else
            {
                return NotFound();
            }
        }

        public IActionResult Confirmation()
        {
            return View("Confirmation");
        }
        public IActionResult Delete(int id )
        {

            Instructor ints = context.Instructors.FirstOrDefault(e => e.Id == id);
            context.Instructors.Remove(ints);
            context.SaveChanges();

            return RedirectToAction("Index"); 
        }

        public IActionResult Search(string Name)
        {
            List<Instructor> inst = context.Instructors.Where(e=>e.Name == Name).ToList();  
            return View("Index", inst);
            
        }

        public IActionResult Add()
        {

            List<Department> dept = context.Departments.ToList();
            List<Course> course = context.Courses.ToList();
             
            InstructorAddViewModel instructorAddViewModel = new InstructorAddViewModel();
            instructorAddViewModel.DeptList = dept;
            instructorAddViewModel.Courses= course;
           
                return View("Add" , instructorAddViewModel);
        }

        /*
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
        {
            var inst = context.Instructors.AsQueryable(); 
            var pagedInstructor = await PaginationViewModel<Instructor>.CreateAsync(inst, pageNumber, pageSize);
            return View(pagedInstructor);
        }
        */
        public IActionResult Index (int pageNumber =1 , int PageSize = 5)
        {

            var inst = context.Instructors.AsQueryable();
            var pagedInstructor = MyPaginationViewModel<Instructor>.Create(inst , pageNumber , PageSize);
            return View("Index", pagedInstructor);
        }

        public async Task<IActionResult> SaveAdd(InstructorAddViewModel mymodel, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

               
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string filePath = Path.Combine(imagesFolder, fileName);
                Console.WriteLine("Saving to: " + filePath);  

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                mymodel.imag = fileName;
            }
           

            if (mymodel.salary != 0 &&  mymodel.imag !=null && mymodel.DeptId!= null && mymodel.CrsId!=null && mymodel.Name!=null)
            {
                Instructor instructor = new Instructor();
                instructor.Name = mymodel.Name;
                instructor.salary = mymodel.salary;
                instructor.imag = mymodel.imag;
                instructor.address = mymodel.address;
                instructor.CrsId = mymodel.CrsId;
                instructor.DeptId = mymodel.DeptId;

                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Department> dept = context.Departments.ToList();
            List<Course> course = context.Courses.ToList();

            mymodel.DeptList = dept;
            mymodel.Courses = course;

            return View("Add", mymodel);
        }
    }

}
