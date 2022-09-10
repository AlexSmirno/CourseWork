namespace Blazor.Data.Models
{
    public class SupplyINDTO
    {
        public int Id { get; set; }
        public string Division { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Supplier { get; set; }
        public string Client { get; set; }
        public IEnumerable<ProductDTO>? Products { get; set; }
    }
}
