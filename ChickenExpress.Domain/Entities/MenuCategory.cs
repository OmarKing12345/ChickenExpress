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
    public class MenuCategory
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        // Nav
        public ICollection<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
}
