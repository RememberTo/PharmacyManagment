using Pharmacy.Application.Infastructure.Interfaces.Base;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Infastructure.Interfaces
{
    public interface IPharmacyRepository : IRepository<Domain.Entities.Pharmacy>
    {
        IDictionary<Part,ProductName> GetAllProductsAndPartiesById(int id);
    }
}
