namespace Services_Repos.Models.Repositories
{
    public interface IRepository<T>
    {
        public T GetById(int id);
        public List<T> GetAll();
        public void Add(T item);
        public void Remove(T item);
        public void Update(T item);
    }
}
