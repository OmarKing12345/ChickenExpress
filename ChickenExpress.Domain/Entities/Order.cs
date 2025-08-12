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
    public class Order
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string OrderNumber { get; set; } = string.Empty;

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DeliveryMode DeliveryMode { get; set; } = DeliveryMode.Delivery;

        [Precision(18, 2)] public decimal Subtotal { get; set; }
        [Precision(18, 2)] public decimal DeliveryFee { get; set; }
        [Precision(18, 2)] public decimal Discount { get; set; }
        [Precision(18, 2)] public decimal Tax { get; set; }
        [Precision(18, 2)] public decimal GrandTotal { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Nav
        public User Customer { get; set; } = default!;
        public Store Store { get; set; } = default!;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
