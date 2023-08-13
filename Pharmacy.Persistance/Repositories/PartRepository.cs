using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Domain.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy.Persistance.Repositories
{
    public class PartRepository : IPartRepository
    {
        private readonly IDbConnection _connection;

        public PartRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Add(Part entity)
        {
            var commandText = @"INSERT INTO Part (ProductNameId, StockId, Count) 
                                VALUES (@ProductNameId, @StockId, @Count)";

            try
            {
                _connection.Open();

                using (var command = new SqlCommand(commandText, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@ProductNameId", entity.ProductNameId);
                    command.Parameters.AddWithValue("@StockId", entity.StockId);
                    command.Parameters.AddWithValue("@Count", entity.Count);

                    command.ExecuteNonQuery();
                }
            }
            finally { _connection.Close(); }
        }

        public void Delete(int id)
        {
            var commandText = "DELETE FROM Part WHERE Id = @Id";

            try
            {
                _connection.Open();

                using (var command = new SqlCommand(commandText, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            finally { _connection.Close(); }
        }
    }
}
