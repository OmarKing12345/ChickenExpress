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
    public class ItemVariant
    {
        public int Id { get; set; }

        [ForeignKey(nameof(MenuItem))]
        public int MenuItemId { get; set; }

        [Required, MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal Price { get; set; }

        // Nav
        public MenuItem MenuItem { get; set; } = default!;
    }
}
