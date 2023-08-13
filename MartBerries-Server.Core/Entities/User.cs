using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartBerries_Server.Core.Entities.ProductTransfer;

namespace MartBerries_Server.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [EnumDataType(typeof(UserRoles))]
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

        public enum UserRoles
        {
            Customer,
            Manager,
            Accountant,
            Stockman,
            SupplierManager,
            Delivery,
            Admin
        }
    }
}
