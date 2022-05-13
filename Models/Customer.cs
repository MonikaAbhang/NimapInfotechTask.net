using System.ComponentModel.DataAnnotations;

namespace NipamInfotechTask.Models
{
    public class Customer
    {
       [Key]
        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

    }
}
