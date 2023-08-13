using Pharmacy.Application.Interfaces;
using Pharmacy.Console.Common;
using Pharmacy.Console.Resources;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Console.Actions
{
    internal class ProductNameAction : IActionConsole
    {
        private readonly IProductNameService _productNameService;

        public ProductNameAction(IProductNameService productNameService)
        {
            _productNameService = productNameService;
        }

        public void Main()
        {
            try
            {
                while (true)
                {
                    System.Console.WriteLine(ResourceMain.ChoseAction);
                    System.Console.WriteLine("\t(1) "+ResourceProductName.AddProduct);
                    System.Console.WriteLine("\t(2) "+ResourceProductName.DeleteProduct);
                    System.Console.WriteLine("\t(3) "+ResourceMain.Close);

                    switch (System.Console.ReadLine())
                    {
                        case "1":
                            AddProduct();
                            break;
                        case "2":
                            DeleteProduct();
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
        private void AddProduct()
        {
            var product = new ProductName
            {
                Name = EnterData.WriteAndReadLine<string>(ResourceProductName.EnterNameProduct),
            };

            _productNameService.Add(product);

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(ResourceProductName.CompleteAddProduct);
            System.Console.ResetColor();
        }

        private void DeleteProduct()
        {
            var id = EnterData.WriteAndReadLine<int>(ResourceProductName.EnterIdProduct);

            _productNameService.Delete(id);

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(ResourceProductName.CompleteDeleteProduct);
            System.Console.ResetColor();
        }
    }
}
