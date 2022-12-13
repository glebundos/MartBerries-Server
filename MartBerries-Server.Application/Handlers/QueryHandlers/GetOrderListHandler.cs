using MartBerries_Server.Application.Mappers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Application.Responses;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartBerries_Server.Core.Entities.Order;

namespace MartBerries_Server.Application.Handlers.QueryHandlers
{
    public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, List<OrderResponse>>
    {
        private IOrderRepository _orderRepo;

        public GetOrderListHandler(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }
        public async Task<List<OrderResponse>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var statusId = request.StatusID;
            if (statusId < -1 || statusId > (int)OrderStatuses.Closed) 
            {
                throw new Exception(statusId.ToString());
            }

            if (statusId == -1)
            {
                var orders = (List<Order>)await _orderRepo.GetAllAsync();
                var responses = OrderMapper.Mapper.Map<List<OrderResponse>>(orders);

                return responses;
            }

            var ordersByStatusId = (List<Order>)await _orderRepo.GetByStatusIdAsync(statusId);
            var responsesByStatusId = OrderMapper.Mapper.Map<List<OrderResponse>>(ordersByStatusId);
            return responsesByStatusId;
        }
    }
}
