using Pharmacy.Console.Resources;

namespace Pharmacy.Console.Common
{
    public static class EnterData
    {
        public static T WriteAndReadLine<T>(string message)
        {
            System.Console.Write(message+": ");
            var input = System.Console.ReadLine();

            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
                
            }
            catch (Exception)
            {
                throw new ArgumentException(ResourceMain.ErorrEnterData);
            }
        }
    }
}
