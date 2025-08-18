//using ChickenExpress.Application.Interfaces;
//using ChickenExpress.Application.ResponsesApi;
//using ChickenExpress.Domain.Entities;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ChickenExpress.Application.Features.ItemVariant.Command.AddItemVariant
//{
//    public class AddItemVariantHandler : ResponseHandler, IRequestHandler<AddItemVariantCommand, Response<bool>>
//    {
//        private readonly IItemVariantService _itemVariantService;

//        public AddItemVariantHandler(IItemVariantService itemVariantService)
//        {
//            _itemVariantService = itemVariantService;
//        }

//        public Task<Response<bool>> Handle(AddItemVariantCommand request, CancellationToken cancellationToken)
//        {
//            var itemVariant = new ItemVariant()
//            {

//            };
//            var result = _itemVariantService.AddItemVariant()
//        }
//    }
//}
