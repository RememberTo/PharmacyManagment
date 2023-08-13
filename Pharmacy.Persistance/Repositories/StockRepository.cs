using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Domain.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy.Persistance.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IDbConnection _connection;

        public StockRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Add(Stock entity)
        {
            var commandText = "INSERT INTO Stock (PharmacyId, Name) VALUES (@PharmacyId, @Name)";

            try
            {
                _connection.Open();

                using (var command = new SqlCommand(commandText, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@PharmacyId", entity.PharmacyId);
                    command.Parameters.AddWithValue("@Name", entity.Name);

                    command.ExecuteNonQuery();
                }
            }
            finally { _connection.Close(); }
        }

        public void Delete(int id)
        {
            var deletePartiesCommandText = @"DELETE FROM Part WHERE StockId IN 
                                                (SELECT Id FROM Stock WHERE Id = @Id)";
            var deleteStockCommandText = "DELETE FROM Stock WHERE Id = @Id";

            try
            {
                _connection.Open();

                using (var command = new SqlCommand(deletePartiesCommandText, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(deleteStockCommandText, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            finally { _connection.Close(); }
        }
    }
}
