using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.ItemVariantt.Command.DeleteItemVariant
{
    public record DeleteItemVariantCommand(int ItemVariantId):IRequest<Response<bool>>
    {

    }
}
