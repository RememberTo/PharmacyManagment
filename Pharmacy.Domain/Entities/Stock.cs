namespace Pharmacy.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public string Name { get; set; }
    }
}
