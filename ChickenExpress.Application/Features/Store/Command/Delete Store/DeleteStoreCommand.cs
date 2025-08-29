using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Command.Delete_Store
{
    public record DeleteStoreCommand(int id):IRequest<Response<bool>>
    {
    }
}
