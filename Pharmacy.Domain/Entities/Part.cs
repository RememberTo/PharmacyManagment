namespace Pharmacy.Domain.Entities
{
    public class Part
    {
        public int Id { get; set; }
        public int ProductNameId { get; set; }
        public int StockId { get; set;}
        public long Count { get; set;}
    }
}
