using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Query.GetStoreById
{
    public record GetStoreByIdQuery(int Id):IRequest<Response<GetStoreByIdResponse>>
    {
    }
}
