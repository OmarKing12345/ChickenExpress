using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChickenExpress.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

         [ForeignKey(nameof(MenuItem))]
        public int? MenuItemId { get; set; }

        [ForeignKey(nameof(Variant))]
        public int? ItemVariantId { get; set; }

        public int Quantity { get; set; }

        [Precision(18, 2)] public decimal UnitPrice { get; set; }
        [Precision(18, 2)] public decimal LineTotal { get; set; }

        // Nav
        public Order Order { get; set; } = default!;
        public MenuItem? MenuItem { get; set; }
        public ItemVariant? Variant { get; set; }
    }
}
