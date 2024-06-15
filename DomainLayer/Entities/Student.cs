
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Student
    {
        [Key]
        public Guid Id { get;  set; }
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        [Required]
        public Guid UserId{ get; set; }
    }
}
