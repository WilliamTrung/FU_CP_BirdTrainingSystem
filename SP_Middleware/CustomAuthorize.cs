using System.Net;
using AuthSubsystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Models.AuthModels;

namespace SP_Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorize : ActionFilterAttribute, IActionFilter
    {
        private bool isAuthorized = true;        
        private List<Models.Enum.Role> _roles = new List<Models.Enum.Role>();
        private IAuthFeature _auth = null!;
        public CustomAuthorize(string? roles)
        {
            if (roles != null)
            {
                var _roles_split = roles.Split(',');
                _roles = _roles_split.Select(str => (Models.Enum.Role)Enum.Parse(typeof(Models.Enum.Role), str)).ToList();
            }
        }
        private void SetConfiguration(ActionExecutingContext context)
        {
            var serviceProvider = context.HttpContext.RequestServices;
            _auth = (IAuthFeature)serviceProvider.GetRequiredService(typeof(IAuthFeature));
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? authHeader = context.HttpContext.Request.Headers["Authorization"];
            SetConfiguration(context);
            TokenModel? authorized = null;
            string message = "Unauthorized";
            try
            {
                authorized = _auth.ValidateToken(authHeader).Result;
                bool roleAuthorized = true;
                if (_roles.Count > 0 && !_roles.Any(r => r == authorized.Role))
                {
                    //role authorizing
                    roleAuthorized = false;
                    message += " - Unauthorized for this function!";
                }
                isAuthorized = roleAuthorized;
                if (!isAuthorized)
                {
                    if (_roles.Count > 0)
                    {
                        message += " - Required Role(s): " + GetAlertRequiredRoles();
                        if (authorized != null)
                        {
                            message += " - Current role: " + authorized.Role.ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                isAuthorized = false;
            }
            if (!isAuthorized)
            {

                context.Result = context.Result = new ObjectResult(message)
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
                return;
            }
        }
        private string GetAlertRequiredRoles()
        {
            string result = "";
            foreach (var item in _roles)
            {
                result += item + ",";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }
    }
}