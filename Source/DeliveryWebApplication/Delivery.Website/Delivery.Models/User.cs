using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "int")]
        public Role Role { get; set; }
    }
}
