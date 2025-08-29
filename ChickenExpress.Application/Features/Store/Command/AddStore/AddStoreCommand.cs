using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Command.AddStore
{
    public record AddStoreCommand(string Name,string? City,string? District,string? AddressText,double? GeoLat,
        double? GeoLng, bool IsOpen):IRequest<Response<bool>>
    {
    }
}
