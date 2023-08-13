namespace Pharmacy.Application.Interfaces
{
    public interface IServiceFactory
    {
        IPharmacyService CreatePharmacyService();
        IStockService CreateStockService();
        IPartService CreatePartService();
        IProductNameService CreateProductNameService();
    }
}
