using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChickenExpress.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? District { get; set; }

        [MaxLength(500)]
        public string? AddressText { get; set; }

        public double? GeoLat { get; set; }
        public double? GeoLng { get; set; }

        public bool IsOpen { get; set; } = true;

        // Nav
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
