using MediatR;
using ChickenExpress.Domain.Entities;
using ChickenExpress.Application.ResponsesApi;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetCart
{
    public record GetCartQuery(string userId) : IRequest<Response<List<CartItem>>>
    {

    }
}
