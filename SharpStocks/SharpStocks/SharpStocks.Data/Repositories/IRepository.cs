namespace SharpStocks.Data
{
    public interface IRepository<in T>
    {
        void Insert(T entity);
        void Upsert(T entity);
        void Delete(T entity);
        void GetById(long id);
    }
}