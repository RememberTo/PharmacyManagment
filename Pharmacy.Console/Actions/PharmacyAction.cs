using Pharmacy.Application.Interfaces;
using Pharmacy.Console.Common;
using Pharmacy.Console.Resources;

namespace Pharmacy.Console.Actions
{
    public class PharmacyAction : IActionConsole
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyAction(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        public void Main()
        {
            try
            {
                while (true)
                {
                    System.Console.WriteLine(ResourceMain.ChoseAction);
                    System.Console.WriteLine("\t(1) "+ResourcePharmacy.AddPharmacy);
                    System.Console.WriteLine("\t(2) "+ResourcePharmacy.DeletePharmacy);
                    System.Console.WriteLine("\t(3) "+ResourcePharmacy.WriteListProduct);
                    System.Console.WriteLine("\t(4) "+ResourceMain.Close);

                    switch (System.Console.ReadLine())
                    {
                        case "1":
                            AddPharmacy();
                            break;
                        case "2":
                            DeletePharmacy();
                            break;
                        case "3":
                            GetProducts();
                            break;
                        case "4":
                            return;
                        default:
                            System.Console.WriteLine(ResourceMain.NotCorrectChose1_4);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private void AddPharmacy()
        {
            var pharamacy = new Domain.Entities.Pharmacy
            {
                Name = EnterData.WriteAndReadLine<string>(ResourcePharmacy.EnterName),
                Address = EnterData.WriteAndReadLine<string>(ResourcePharmacy.EnterAdress),
                Phone = EnterData.WriteAndReadLine<string>(ResourcePharmacy.EnterPhone),
            };

            _pharmacyService.Add(pharamacy);

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(ResourcePharmacy.CompleteAddPharmacy);
            System.Console.ResetColor();
        }

        private void DeletePharmacy()
        {
            var id = EnterData.WriteAndReadLine<int>(ResourcePharmacy.EnterIdPharmacy);

            _pharmacyService.Delete(id);

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(ResourcePharmacy.CompleteDeletePharmacy);
            System.Console.ResetColor();
        }

        private void GetProducts()
        {
            var id = EnterData.WriteAndReadLine<int>(ResourcePharmacy.EnterIdPharmacy);

            var products = _pharmacyService.GetProductsWithQuantitiesInPharmacy(id);

            System.Console.WriteLine("");
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine("|" + ResourcePharmacy.TableName.PadRight(13) + "|\t" + ResourcePharmacy.TableCount.PadLeft(12) + "|");
            System.Console.WriteLine("-----------------------------");

            foreach (var product in products)
            {
                string productName = product.Name.PadRight(13);
                string productCount = product.Count.ToString().PadLeft(12);
                System.Console.WriteLine($"|{productName}|\t{productCount}|");
                System.Console.WriteLine("-----------------------------");
            }

            System.Console.WriteLine("");
        }
    }
}
