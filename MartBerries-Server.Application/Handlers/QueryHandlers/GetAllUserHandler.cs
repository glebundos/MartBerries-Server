using MartBerries_Server.Application.Mappers;
using MartBerries_Server.Application.Models;
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
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<UserResponse>>
    {
        private readonly IUserRepository _userRepo;

        public GetAllUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = (List<User>)await _userRepo.GetAllAsync();

            return UserMapper.Mapper.Map<List<UserResponse>>(users);
        }
    }
}
