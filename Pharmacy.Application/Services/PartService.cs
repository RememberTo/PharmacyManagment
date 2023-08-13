using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Application.Interfaces;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Services
{
    public class PartService : IPartService
    {
        private readonly IPartRepository _partRepository;

        public PartService(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public void Add(Part pharmacy)
        {
            _partRepository.Add(pharmacy);
        }

        public void Delete(int id)
        {
           _partRepository.Delete(id);
        }
    }
}
