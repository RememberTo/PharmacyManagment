using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Domain.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy.Persistance.Repositories
{
    public class ProductNameRepository : IProductNameRepository
    {
        private readonly IDbConnection _connection;

        public ProductNameRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Add(ProductName entity)
        {
            var commandText = "INSERT INTO ProductName (Name) VALUES (@Name)";

            try
            {
                _connection.Open();

                using (var command = new SqlCommand(commandText, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Name);

                    command.ExecuteNonQuery();
                }
            }
            finally { _connection.Close(); }
        }

        public void Delete(int id)
        {
            var commandText = "DELETE FROM ProductName WHERE Id = @Id";

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
