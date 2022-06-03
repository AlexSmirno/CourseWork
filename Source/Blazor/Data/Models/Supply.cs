namespace Blazor.Data.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public string Division { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
