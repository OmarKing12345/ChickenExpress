using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChickenExpress.Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Description { get; set; }

        [MaxLength(1000)]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        // Nav
        public MenuCategory Category { get; set; } = default!;
        public ICollection<ItemVariant> Variants { get; set; } = new List<ItemVariant>();

    }
}
