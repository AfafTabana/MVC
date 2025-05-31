using MVC.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CourseAddViewModel mycourse = (CourseAddViewModel)validationContext.ObjectInstance;

            string Name = value.ToString(); 
            ITIContext context = new ITIContext(); 

            Course existedcourse = context.Courses.FirstOrDefault(e=>e.Name == Name && mycourse.DeptId == e.DeptId);

            if (existedcourse == null) {
                return ValidationResult.Success; 
            }else
            {
                return new ValidationResult("Name In The Same Department Already Exists !!!");
            }
         
        }
    }
}
