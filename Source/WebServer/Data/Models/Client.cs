using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Data.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Negotiator { get; set; }
        public string? DateStart { get; set; }
        public string? DateEnd { get; set; }
        public virtual IEnumerable<Supply>? Supplies { get; set; }
    }
}
