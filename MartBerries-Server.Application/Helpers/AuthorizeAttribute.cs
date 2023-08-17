using MartBerries_Server.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MartBerries_Server.Application.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _requiredRoleId;
        // -2 - everyone
        // -1 - everyone except Customer

        public AuthorizeAttribute()
        {
            _requiredRoleId = -2;
        }

        public AuthorizeAttribute(int requiredRoleId)
        {
            _requiredRoleId = requiredRoleId;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else if (user.UserRoleId != _requiredRoleId)
            {
                if (user.UserRoleId == 6 || _requiredRoleId == -2)
                {
                    // admin or tab for everyone
                }
                else if (user.UserRoleId > 0 && _requiredRoleId == -1)
                {
                    // staff and for staff
                }
                else 
                {
                    // wrong role
                    context.Result = new JsonResult(new { message = "Not enough rights" }) { StatusCode = CustomStatusCodes.Status452NotEnoughRights };
                }
            }
        }
    }
}
