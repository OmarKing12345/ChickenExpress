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
    public class Payment
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        [Required, MaxLength(80)]
        public string Provider { get; set; } = "Cash";

        [Precision(18, 2)]
        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; } = PaymentStatus.Unpaid;
        public DateTime? PaidAt { get; set; }

        // Nav
        public Order Order { get; set; } = default!;
    }
}
