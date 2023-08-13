using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Application.Interfaces;
using Pharmacy.Application.Models;

namespace Pharmacy.Application.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public void Add(Domain.Entities.Pharmacy pharmacy)
        {
            _pharmacyRepository.Add(pharmacy);
        }

        public void Delete(int id)
        {
            _pharmacyRepository.Delete(id);
        }

        public IEnumerable<ProductPatries> GetProductsWithQuantitiesInPharmacy(int id)
        {
            var productAndPartiesDict= _pharmacyRepository.GetAllProductsAndPartiesById(id);
            return productAndPartiesDict.
                Select(p => new ProductPatries 
                { 
                    Count = p.Key.Count, 
                    Name = p.Value.Name 
                });
        }
    }
}
