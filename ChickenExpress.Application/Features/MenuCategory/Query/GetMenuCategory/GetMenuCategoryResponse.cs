using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories
{
    public class GetMenuCategoryResponse
    {

        public string Name { get; set; } = string.Empty;

        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;

    }
}
