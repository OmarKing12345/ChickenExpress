using ChickenExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems
{
    public class GetMenuItemsResponse
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
 
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
