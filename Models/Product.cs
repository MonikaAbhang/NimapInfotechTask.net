using System.ComponentModel.DataAnnotations;

namespace NipamInfotechTask.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }
    }
}
