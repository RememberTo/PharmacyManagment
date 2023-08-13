using Pharmacy.Application.Interfaces;
using Pharmacy.Console.Common;
using Pharmacy.Console.Resources;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Console.Actions
{
    internal class StockAction : IActionConsole
    {
        private readonly IStockService _stockService;

        public StockAction(IStockService stockService)
        {
            _stockService = stockService;
        }

        public void Main()
        {
            try
            {
                while (true)
                {
                    System.Console.WriteLine(ResourceMain.ChoseAction);
                    System.Console.WriteLine("\t(1) "+ResourceStock.AddStock);
                    System.Console.WriteLine("\t(2) "+ResourceStock.DeleteStock);
                    System.Console.WriteLine("\t(3) "+ResourceMain.Close);

                    switch (System.Console.ReadLine())
                    {
                        case "1":
                            AddStock();
                            break;
                        case "2":
                            DeleteStock();
                            break;
                        case "3":
                            return;
                        default:
                            System.Console.WriteLine(ResourceMain.NotCorrectChose1_3);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        private void AddStock()
        {
            var stock = new Stock
            {
                Name = EnterData.WriteAndReadLine<string>(ResourceStock.EnterNameStock),
                PharmacyId = EnterData.WriteAndReadLine<int>(ResourceStock.EnterIdPharmacy),
            };

            _stockService.Add(stock);

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(ResourceStock.CompleteAddStock);
            System.Console.ResetColor();
        }

        private void DeleteStock()
        {
            var id = EnterData.WriteAndReadLine<int>(ResourceStock.EnterIdStock);

            _stockService.Delete(id);

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(ResourceStock.CompleteDeleteStock);
            System.Console.ResetColor();
        }
    }
}
