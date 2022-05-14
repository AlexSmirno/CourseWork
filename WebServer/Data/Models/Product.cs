using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Data.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Number { get; set; }
        public int SupplyId { get; set; }
        public virtual Supply? Supply { get; set; }
    }
}
