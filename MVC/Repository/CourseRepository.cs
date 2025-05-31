using MVC.Models;

namespace MVC.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ITIContext ITIContext;
        public CourseRepository(ITIContext _context) { 
             
            ITIContext = _context;
        }
        public void Add(Course obj)
        {
            ITIContext.Courses.Add(obj);
        }

        public void Delete(Course obj)
        {
            ITIContext.Courses.Remove(obj); 
        }

        public List<Course> GetAll()
        {
           List<Course> list = ITIContext.Courses.ToList();

           return list;
        }

        public Course GetById(int id)
        {
            Course mycourse = ITIContext.Courses.FirstOrDefault(e => e.Id == id);
            return mycourse;
        }

        public void Save()
        {
            ITIContext.SaveChanges();

        }


        public void Update(Course obj)
        {
            Course crs = GetById(obj.Id);
            crs.hours = obj.hours;
            crs.degree = obj.degree;    
            crs.mindegree = obj.mindegree;
            crs.Name = obj.Name; 
            crs.DeptId = obj.DeptId;
          

        }
    }
}
