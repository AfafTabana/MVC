using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Instructor
    {

        public int Id { get; set; }

        public string Name { set; get; }

        public string imag { set; get; }

        public int salary { set; get; }

        public string? address { set; get; }

        [ForeignKey("department")]
        public int DeptId { get; set; }

        public Department? department { get; set; }

        [ForeignKey("course")]
        public int CrsId { get; set; }

        public Course? course { get; set; }

    }
}
