using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Data.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public virtual IEnumerable<Supply>? Supplies { get; set; }
    }
}
