using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.ItemVariantt.Command.UpdateItemVariant
{
    public record UpdateItemVariantCommand(int Id, int? MenuItemId, string? Name, decimal? Price):IRequest<Response<bool>>
    {
    }
}
