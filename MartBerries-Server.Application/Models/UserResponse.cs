using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartBerries_Server.Core.Entities.User;

namespace MartBerries_Server.Application.Models
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public UserRoles UserRole { get; set; }

        [Required]
        public virtual int UserRoleId
        {
            get
            {
                return (int)UserRole;
            }
            set
            {
                UserRole = (UserRoles)value;
            }
        }
    }
}
