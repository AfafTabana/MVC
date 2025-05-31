using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViewModels;
using System.Security.Cryptography;

namespace MVC.Controllers
{
    public class TraineeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Result(int Tid , int Cid )
        {
          
           var q1 = context.CourseResult.FirstOrDefault(e => e.traineeId == Tid && e.CrsId == Cid);
           var course = context.Courses.FirstOrDefault(e => e.Id == Cid);
           var trainee = context.Trainees.FirstOrDefault(e => e.Id == Tid);
           
            CourseResultViewModel newmodel = new CourseResultViewModel();
            newmodel.traineeName = trainee.Name;
            newmodel.CourseName = course.Name;
            newmodel.degree = q1.degree; 
            if (q1.degree > course.mindegree)
            {
                newmodel.Color = "green";
                newmodel.Status = "pass"; 
            }else
            {
                newmodel.Color = "red";
                newmodel.Status = "fail";
            }

            return View("Result",newmodel);
           



        }

        public IActionResult TraineeResult(int Tid)
        {
            var q1 = context.CourseResult.Where(e => e.traineeId == Tid);
            var traineeName = context.Trainees.FirstOrDefault(e => e.Id == Tid);

           List< CourseResultViewModel> mylist = new List<CourseResultViewModel>();

           List<Course> mycourses = context.Courses.ToList();
            foreach (var trinee in q1)
            {
                CourseResultViewModel newmodel = new CourseResultViewModel();
                var course = mycourses.FirstOrDefault(e => e.Id == trinee.CrsId);
                newmodel.traineeName = traineeName.Name;
                newmodel.degree = trinee.degree;
                newmodel.CourseName = course.Name;
                if (trinee.degree > course.mindegree)
                {
                    newmodel.Color = "green";
                    newmodel.Status = "pass";
                }
                else
                {
                    newmodel.Color = "red";
                    newmodel.Status = "fail";
                }

                mylist.Add(newmodel);

            }
          
          

            return View ("TraineeResult", mylist);

        }

        public IActionResult CourseResult(int CrsId)
        {
           List<crsResult> result =  context.CourseResult
                                           .Where(e=> e.CrsId == CrsId)
                                           .Include(e=> e.course)
                                           .Include(t=>t.trainee)
                                           .ToList();

            List<CourseResultViewModel> mylist = new();

            foreach (var crs in result) {

                CourseResultViewModel model = new CourseResultViewModel();
                model.traineeName = crs.trainee.Name;
                model.CourseName = crs.course.Name; 
                model.degree = crs.degree;
                
                if (crs.degree > crs.course.mindegree)
                {
                    model.Color = "green";
                    model.Status = "Passed"; 
                }else
                {
                    model.Color = "red";
                    model.Status = "Failed";
                }

                mylist .Add(model);
            }

            return View("CourseResult" , mylist);   
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
