namespace MVC.Models
{
    public class Department
    {

        public int Id { get; set; }

        public string Name { set; get; }

        public string? ManagerName { set; get; }

        public List<Instructor> instructors { get; set; }

        public List<Trainee> trainees { get; set; }

        public List<Course> courses { get; set; }
    }
}
