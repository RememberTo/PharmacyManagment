using Pharmacy.Application.Interfaces;
using Pharmacy.Application.Services;
using Pharmacy.Console.Actions;
using Pharmacy.Console.Resources;
using Pharmacy.Persistance.Repositories.Factory;
using System.Data;

namespace Pharmacy.Console
{
    internal class Startup
    {
        private readonly IDbConnection _connection;
        private readonly IServiceFactory _serviceFactory;

        public Startup(IDbConnection connection)
        {
            _connection = connection;
            _serviceFactory = new ServiceFactory(new RepositoryFactory(_connection));
        }

        internal void Run()
        {
            try
            {
                var exit = false;
                while (!exit)
                {
                    System.Console.WriteLine(ResourceMain.ChoseAction);
                    System.Console.WriteLine("\t(1) "+ResourceMain.Pharmacy);
                    System.Console.WriteLine("\t(2) "+ResourceMain.Stock);
                    System.Console.WriteLine("\t(3) "+ResourceMain.ProductName);
                    System.Console.WriteLine("\t(4) "+ResourceMain.Part);
                    System.Console.WriteLine("\t(5) "+ResourceMain.Close);

                    IActionConsole? action = null;
                    switch (System.Console.ReadLine())
                    {
                        case "1":
                            action = new PharmacyAction(_serviceFactory.CreatePharmacyService());
                            break;
                        case "2":
                            action = new StockAction(_serviceFactory.CreateStockService());
                            break;
                        case "3":
                            action = new ProductNameAction(_serviceFactory.CreateProductNameService());
                            break;
                        case "4":
                            action = new PartAction(_serviceFactory.CreatePartService());
                            break;
                        case "5":
                            exit = true;
                            break;
                        default:
                            System.Console.WriteLine(ResourceMain.NotCorrectChose1_5);
                            break;
                    }
                    if (action != null)
                    {
                        action.Main();
                        action = null;
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
