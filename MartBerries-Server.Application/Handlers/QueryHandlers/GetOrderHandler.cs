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
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, Order>
    {
        private readonly IOrderRepository _orderRepo;

        public GetOrderHandler(IOrderRepository orderRepo) => _orderRepo = orderRepo;

        public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            try 
            {
                var order = await _orderRepo.GetByIdAsync(request.Id);
                return order;
            }
            catch
            {
                throw new Exception(message: "Order not found");
            }
        }
    }
}
