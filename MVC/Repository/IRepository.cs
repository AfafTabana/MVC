using MVC.Models;

namespace MVC.Repository
{
    public interface IRepository<T>
    {
        public void Add(T obj);

        public T GetById(int id);

        public void Update(T obj);

        public List<T> GetAll();

        public void Delete(T obj);

        public void Save();
    }
}
