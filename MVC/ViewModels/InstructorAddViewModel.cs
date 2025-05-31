using MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.ViewModels
{
    public class InstructorAddViewModel
    {
        public int Id { get; set; }

        public string Name { set; get; }

        public string imag { set; get; }

        public int salary { set; get; }

        public string address { set; get; }

        public int DeptId { get; set; }

        public int CrsId { get; set; }

        public List<Department> DeptList { get; set; }

        public List<Course> Courses { get; set; }
    }
}
