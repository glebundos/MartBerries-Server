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
    public class GetAllUserQuery : IRequest<List<UserResponse>>
    {
    }
}
