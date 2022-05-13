using System.ComponentModel.DataAnnotations.Schema;

namespace NipamInfotechTask.Models
{
    public class AllList
    {

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public string? ProductName { get; set; }
        [ForeignKey("ProductName")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public string? CustomerName { get; set; }
  
    }

}
