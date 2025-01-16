namespace Services_Repos.Services
{
    public interface IService<T>
    {

        public T GetById(int id);
        public List<T> GetAll();
        public void Add(T item);
        public void Remove(int id);
        public void Update(T item);
    }
}
