using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CourseAddViewModel
    {

        public int Id { get; set; }
        [Unique]
        [MaxLength(25 , ErrorMessage = "Name Must Be Less Than 25")]
        public string Name { set; get; }
        [Range(50, 100)]
        public int degree { set; get; }

        [Remote("Greater" , "Course" , AdditionalFields = "degree" , ErrorMessage ="Mindegree Can't be Greater Than degree")]
        public int mindegree { set; get; }
        [Hour]
        public int hours { set; get; }

        public int DeptId { get; set; }

        public List<Department>? detps { set; get; }
    }
}
