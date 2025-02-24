﻿
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Admin
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
