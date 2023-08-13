using Pharmacy.Application.Infastructure.Interfaces.Factory;
using Pharmacy.Application.Interfaces;

namespace Pharmacy.Application.Services
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public ServiceFactory(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IPartService CreatePartService()
        {
            return new PartService(_repositoryFactory.CreatePartRepository());
        }

        public IPharmacyService CreatePharmacyService()
        {
            return new PharmacyService(_repositoryFactory.CreatePharmacyRepository());
        }

        public IProductNameService CreateProductNameService()
        {
            return new ProductNameService(_repositoryFactory.CreateProductNameRepository());
        }

        public IStockService CreateStockService()
        {
            return new StockService(_repositoryFactory.CreateStockRepository());
        }
    }
}
