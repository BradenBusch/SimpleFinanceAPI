using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleFinanceAPI.Models
{
    public class AccountDetail
    {
        [Key]
        public Guid AccountDetailId { get; set; }
        public Guid AccountId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccountValue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
