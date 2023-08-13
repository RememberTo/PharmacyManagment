using Pharmacy.Application.Interfaces.Base;
using Pharmacy.Application.Models;

namespace Pharmacy.Application.Interfaces
{
    public interface IPharmacyService : IService<Domain.Entities.Pharmacy>
    {
        IEnumerable<ProductPatries> GetProductsWithQuantitiesInPharmacy(int id);
    }
}
