using MediatR;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Domain.Entities;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetCart
{
    public class GetCartHandler : ResponseHandler, IRequestHandler<GetCartQuery, Response<List<CartItem>>>
    {
        private readonly ICartService _cartService;

        public GetCartHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Response<List<CartItem>>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
             var allCartItems = await _cartService.GetAllCartsAsync(request.userId);

             if (allCartItems == null || !allCartItems.Any())
            {
                return NotFound<List<CartItem>>("لا توجد سلات");
            }

            return Success(allCartItems, message: "تم جلب السلات بنجاح");
        }
    }
}
