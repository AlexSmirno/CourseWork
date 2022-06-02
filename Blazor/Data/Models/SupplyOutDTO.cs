namespace Blazor.Data.Models
{
    public class SupplyOutDTO
    {
        public int Id { get; set; }
        public int SupplyINId { get; set; }
        public string Division { get; set; }
        public static readonly string Type = "OUT";
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
