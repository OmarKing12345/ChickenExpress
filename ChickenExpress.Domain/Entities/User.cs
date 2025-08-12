using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Domain.Enums;

namespace ChickenExpress.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(40)]
        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Nav
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
