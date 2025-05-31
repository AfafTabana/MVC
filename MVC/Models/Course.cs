using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { set; get; }
        
        public int degree { set; get; }

        public int mindegree { set; get; }

        public int hours { set; get; }

        [ForeignKey("department")]
        public int DeptId { get; set; }

        public Department? department { get; set; }

        public List<Instructor> instructors { get; set; }

        public List<crsResult> _courseresult { get; set; }
    }
}
