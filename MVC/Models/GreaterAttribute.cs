using System.ComponentModel.DataAnnotations;
using MVC.ViewModels;
namespace MVC.Models
{
    public class HourAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CourseAddViewModel mycourse = (CourseAddViewModel)validationContext.ObjectInstance;
            if (mycourse.hours % 3==0) {
            

                return ValidationResult.Success;
            
            }else
            {

                return new ValidationResult("Hours Must be Multipliable by 3 !!!"); 

            }
           
        }
    }
}
