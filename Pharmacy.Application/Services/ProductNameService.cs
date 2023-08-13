using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Application.Interfaces;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Services
{
    public class ProductNameService : IProductNameService
    {
        private readonly IProductNameRepository _productNameRepository;

        public ProductNameService(IProductNameRepository productNameRepository)
        {
            _productNameRepository = productNameRepository;
        }

        public void Add(ProductName pharmacy)
        {
            _productNameRepository.Add(pharmacy);
        }

        public void Delete(int id)
        {
            _productNameRepository.Delete(id);
        }
    }
}
