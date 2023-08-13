using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Application.Infastructure.Interfaces.Factory;
using System.Data;

namespace Pharmacy.Persistance.Repositories.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IDbConnection _connection;

        public RepositoryFactory(IDbConnection connection)
        {
            _connection = connection;
        }
        public IPartRepository CreatePartRepository()
        {
            return new PartRepository(_connection);
        }

        public IPharmacyRepository CreatePharmacyRepository()
        {
            return new PharmacyRepository(_connection);
        }

        public IProductNameRepository CreateProductNameRepository()
        {
            return new ProductNameRepository(_connection);
        }

        public IStockRepository CreateStockRepository()
        {
            return new StockRepository(_connection);
        }
    }
}
