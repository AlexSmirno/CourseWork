namespace WebServer.Data.DTO
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int[] Supplies { get; set; }
    }
}
