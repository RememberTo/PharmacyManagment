using Pharmacy.Application.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Infastructure.Interfaces.Factory
{
    public interface IRepositoryFactory
    {
        IProductNameRepository CreateProductNameRepository();
        IPharmacyRepository CreatePharmacyRepository();
        IStockRepository CreateStockRepository();
        IPartRepository CreatePartRepository();
    }
}
