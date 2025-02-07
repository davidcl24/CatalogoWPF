using Services_Repos.Models.Data_Classes;

namespace Services_Repos.Services
{
    public interface IService<T>
    {

        public T GetById(int id);
        public Task<List<T>> GetAllAsync();
        public void Add(T item);
        public void Remove(int id);
        public void Update(T item);
    }
}
