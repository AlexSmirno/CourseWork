namespace WebServer.Data.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public string? Date { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Number { get; set; }
        public int SupplyId { get; set; }
        public string? SupplierCompany { get; set; }
        public string? ClientCompany { get; set; }
    }
}
