namespace Pharmacy.Application.Infastructure.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int id);
    }
}
