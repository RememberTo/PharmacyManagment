using Pharmacy.Application.Infastructure.Interfaces;
using Pharmacy.Domain.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy.Persistance.Repositories
{
    internal class PharmacyRepository : IPharmacyRepository
    {
        private readonly IDbConnection _connection;

        public PharmacyRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Add(Domain.Entities.Pharmacy entity)
        {
            var commandText = "INSERT INTO Pharmacy (Name, Address, Phone) VALUES (@Name, @Address, @Phone)";

            try
            {
                _connection.Open();

                using (var command = new SqlCommand(commandText, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Name);
                    command.Parameters.AddWithValue("@Address", entity.Address);
                    command.Parameters.AddWithValue("@Phone", entity.Phone);

                    command.ExecuteNonQuery();
                }
            }
            finally { _connection.Close(); }
        }

        public void Delete(int id)
        {
            var deletePartiesCommandText = @"DELETE FROM Part WHERE StockId IN 
                                                (SELECT Id FROM Stock WHERE PharmacyId IN 
                                                    (SELECT Id FROM Pharmacy WHERE Id = @Id))";

            var deleteStockCommandText = @"DELETE FROM Stock WHERE PharmacyId IN 
                                            (SELECT Id FROM Pharmacy WHERE Id = @Id)";
            var deletePharmacy = "DELETE FROM Pharmacy WHERE Id = @Id";

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
                using (var command = new SqlCommand(deletePharmacy, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            finally { _connection.Close(); }
        }

        public IDictionary<Part, ProductName> GetAllProductsAndPartiesById(int pharmacyId)
        {
            var productsAndParties = new Dictionary<Part, ProductName>();

            var commandText = @"
                SELECT pn.Id as ProductNameId, pn.Name, SUM(p.Count) as TotalCount
                FROM Part p
                INNER JOIN Stock s ON p.StockId = s.Id
                INNER JOIN ProductName pn ON p.ProductNameId = pn.Id
                WHERE s.PharmacyId = @PharmacyId
                GROUP BY pn.Id, p.ProductNameId, pn.Name
                ";
            try
            {
                using (var command = new SqlCommand(commandText, (SqlConnection)_connection))
                {
                    command.Parameters.AddWithValue("@PharmacyId", pharmacyId);

                    _connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var part = new Part
                            {
                                ProductNameId = reader.GetInt32(reader.GetOrdinal("ProductNameId")),
                                Count = reader.GetInt64(reader.GetOrdinal("TotalCount"))
                            };

                            var productName = new ProductName
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ProductNameId")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            };

                            productsAndParties.Add(part, productName);
                        }
                    }
                }
            }
            finally { _connection.Close(); }

            return productsAndParties;
        }
    }
}
