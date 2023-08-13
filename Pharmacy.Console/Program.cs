using Pharmacy.Console;
using Pharmacy.Console.Configuration;
using Pharmacy.Console.Resources;
using System.Data.SqlClient;

try
{
    var configuration = new AppConfiguration();

    var connection = new SqlConnection(configuration["DbConnection"]);
    try
    {
        #region Status db in console
        Console.WriteLine(ResourceMain.PropertyConnect);
        Console.WriteLine("\t"+ResourceMain.StringConnect+" {0}", connection.ConnectionString);
        Console.WriteLine("\t"+ResourceMain.Database+" {0}", connection.Database);
        Console.WriteLine("\t"+ResourceMain.Server+" {0}", connection.DataSource);
        Console.WriteLine("\t"+ResourceMain.Status+" {0}", connection.State);
        Console.WriteLine("\t"+ResourceMain.WorkstationId+" {0}", connection.WorkstationId);
        #endregion

        var startup = new Startup(connection);

        startup.Run();
    }
    catch (Exception)
    {

    }
    finally
    {
        connection.Close();
    }
}
catch (Exception)
{
    
}

