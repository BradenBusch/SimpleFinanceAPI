using System.ComponentModel.DataAnnotations;

namespace SimpleFinanceAPI.Models
{
    public class User
    {
        // i believe using a cookie to save the user id in teh session would be enough
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserPhone { get; set; } = string.Empty;

    }
}
