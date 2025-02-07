using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinanceAPI.Models
{
    public class AccountHeader
    {
        [Key]
        public Guid AccountId { get; set; } 
        public Guid UserId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccountValue { get; set; }
        public int AccountType { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string AccountDescription { get; set; } = string.Empty;
        public string AccountPhone { get; set; } = string.Empty; 
    }
}
