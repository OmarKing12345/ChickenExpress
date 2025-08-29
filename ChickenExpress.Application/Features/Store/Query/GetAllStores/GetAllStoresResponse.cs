using ChickenExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Query.GetAllStores
{
    public class GetAllStoresResponse
    {
        public string Name { get; set; } = string.Empty;

        public string? City { get; set; }

        public string? District { get; set; }

        public string? AddressText { get; set; }

        public double? GeoLat { get; set; }
        public double? GeoLng { get; set; }

        public bool IsOpen { get; set; } = true;

    }
}
