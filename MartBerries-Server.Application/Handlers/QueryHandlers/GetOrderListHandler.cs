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
    public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, List<Order>>
    {
        private IOrderRepository _orderRepo;

        public GetOrderListHandler(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }
        public async Task<List<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var statusId = request.StatusID;
            if (statusId == -1)
            {
                return (List<Order>)await _orderRepo.GetAllAsync();
            }

            return (List<Order>)await _orderRepo.GetByStatusIdAsync(statusId);
        }
    }
}
