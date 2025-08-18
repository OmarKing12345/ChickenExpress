using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetMenuCategories
{
    public class GetMenuCategoryResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;

    }
}
