namespace Blazor.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual IEnumerable<Supply>? Supplies { get; set; }
    }
}
