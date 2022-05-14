namespace WebServer.Data.DTO
{
    public class ClientDTO
    {
        public int Id {get;set;}
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Negotiator { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public int[] Supplies { get; set; }
    }
}
