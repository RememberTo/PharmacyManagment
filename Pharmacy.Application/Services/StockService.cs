using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Application.Interfaces;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public void Add(Stock pharmacy)
        {
            _stockRepository.Add(pharmacy);
        }

        public void Delete(int id)
        {
            _stockRepository.Delete(id);
        }
    }
}
