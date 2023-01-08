using MartBerries_Server.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Commands
{
    public class RegistrateCommand : IRequest<AuthenticateResponse>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
