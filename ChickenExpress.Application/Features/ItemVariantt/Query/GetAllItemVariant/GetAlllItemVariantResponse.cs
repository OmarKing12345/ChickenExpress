using ChickenExpress.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.ItemVariant.Command.GetAllItemVariant
{
    public class GetAlllItemVariantResponse
    {

        public int MenuItemId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }


    }
}
