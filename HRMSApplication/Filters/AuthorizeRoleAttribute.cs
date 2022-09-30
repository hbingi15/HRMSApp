using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using IAuthorizationFilter = System.Web.Http.Filters.IAuthorizationFilter;

namespace HRMSApplication.Filters
{
    public class AuthorizeRoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _actionName;
        private readonly string _roleType;
        public AuthorizeRoleAttribute(string actionName, string roleType)
        {
            _actionName = actionName;
            _roleType = roleType;
        }

        bool IFilter.AllowMultiple => throw new NotImplementedException();

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string _roleType = context.HttpContext.Request?.Headers["role"].ToString();
            if (_roleType == null)
                context.Result = new JsonResult("Permission denined!");
            switch (_actionName)
            {
                case "Index":
                    if (!_roleType.Contains("Admin"))
                    {
                        context.Result = new JsonResult("Permission denined!");
                        context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                    }
                    break;
            }
        }

        Task<HttpResponseMessage> IAuthorizationFilter.ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            throw new NotImplementedException();
        }
    }

}

