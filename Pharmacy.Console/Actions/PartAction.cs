using Pharmacy.Application.Interfaces;
using Pharmacy.Console.Common;
using Pharmacy.Console.Resources;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Console.Actions
{
    internal class PartAction : IActionConsole
    {
        private readonly IPartService _partService;

        public PartAction(IPartService partService)
        {
            _partService = partService;
        }

        public void Main()
        {
            try
            {
                while (true)
                {
                    System.Console.WriteLine(ResourceMain.ChoseAction);
                    System.Console.WriteLine("\t(1) "+ResourcePart.AddPart);
                    System.Console.WriteLine("\t(2) "+ResourcePart.DeletePart);
                    System.Console.WriteLine("\t(3) "+ResourceMain.Close);

                    switch (System.Console.ReadLine())
                    {
                        case "1":
                            AddPart();
                            break;
                        case "2":
                            DeletePart();
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
        private void AddPart()
        {
            var part = new Part
            {
                ProductNameId = EnterData.WriteAndReadLine<int>(ResourcePart.EnterIdProductName),
                StockId = EnterData.WriteAndReadLine<int>(ResourcePart.EnterIdStock),
                Count = EnterData.WriteAndReadLine<int>(ResourcePart.EnterCountPart),
            };

            _partService.Add(part);

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(ResourcePart.CompleteAddPart);
            System.Console.ResetColor();
        }

        private void DeletePart()
        {
            var id = EnterData.WriteAndReadLine<int>(ResourcePart.EnterIdPart);

            _partService.Delete(id);

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(ResourcePart.CompleteDeletePart);
            System.Console.ResetColor();
        }   
    }
}
