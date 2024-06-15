
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHashed { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
