using MartBerries_Server.Application.Responses;
using MartBerries_Server.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Queries
{
    public class GetOrderListQuery : IRequest<List<OrderResponse>>
    {
        public GetOrderListQuery(int statusID)
        {
            StatusID = statusID;
        }

        public GetOrderListQuery()
        {
            StatusID = -1;
        }

        public int StatusID { get; }
    }
}
