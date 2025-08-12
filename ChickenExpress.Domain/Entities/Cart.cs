using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChickenExpress.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }

         public int UserId { get; set; }
        public User User { get; set; } = default!;

         public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

         public bool IsCheckedOut { get; set; } = false;

         public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }
    }
}
