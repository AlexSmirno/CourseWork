namespace WebServer.Data.DTO
{
    public class SupplyOUTDTO
    {
        public int Id { get; set; }
        public int SupplyINId { get; set; }
        public string Division { get; set; }
        public string Supplier { get; set; }
        public string Client { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
