using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.QueryHandlers
{
    public class GetAllProductTransferHandler : IRequestHandler<GetAllProductTransferQuery, List<ProductTransfer>>
    {
        private readonly IProductTransferRepository _productTransferRepo;

        public GetAllProductTransferHandler(IProductTransferRepository productTransferRepo) => _productTransferRepo = productTransferRepo;

        public async Task<List<ProductTransfer>> Handle(GetAllProductTransferQuery request, CancellationToken cancellationToken)
        {
            var transferProducts = (List<ProductTransfer>)await _productTransferRepo.GetAllAsync();

            return transferProducts;
        }
    }
}
