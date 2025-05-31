using MVC.Models;

namespace MVC.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext context; 

        public DepartmentRepository()
        {
            context = new ITIContext();
        }
        public void Add(Department obj)
        {
            context.Departments.Add(obj);
        }

        public void Delete(Department obj)
        {
            context.Departments.Remove(obj);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(e=>e.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            
            Department dept = GetById(obj.Id);
            dept.Name = obj.Name;
            dept.ManagerName = obj.ManagerName;
        }
    }
}
