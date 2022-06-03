namespace WebServer.Data.DTO
{
    public class SupplyDTO
    {
        public string Division { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Supplier { get; set; }
        public int[] Products { get; set; }
    }
}
