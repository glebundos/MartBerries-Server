using MartBerries_Server.Application.Models;
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
        public GetOrderListQuery(int statusID, int roleID)
        {
            StatusID = statusID;
            RoleID = roleID;
        }

        public GetOrderListQuery(int roleID)
        {
            StatusID = -1;
            RoleID = roleID;
        }

        public int StatusID { get; }

        public int RoleID { get; }
    }
}
