using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SP_Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class Authorize : ActionFilterAttribute, IActionFilter
    {
        //private bool isAuthorized = true;
        //private bool _requiredPhone;
        //private List<EnumModel.Role> _roles = new List<EnumModel.Role>();
        //private IAccountService _loginService = null!;
        //public Authorize(string? roles, bool requiredPhone = false)
        //{
        //    if(roles != null)
        //    {
        //        var _roles_split = roles.Split(',');
        //        _roles = _roles_split.Select(str => (EnumModel.Role)Enum.Parse(typeof(EnumModel.Role), str)).ToList();
        //    }            
        //    _requiredPhone = requiredPhone;
        //}
        //public Authorize(bool requiredPhone = false)
        //{
        //    _requiredPhone = requiredPhone;
        //}
        //private void SetConfiguration(ActionExecutingContext context)
        //{
        //    var serviceProvider = context.HttpContext.RequestServices;
        //    _loginService = (IAccountService)serviceProvider.GetRequiredService(typeof(IAccountService));
        //}
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    string? authHeader = context.HttpContext.Request.Headers["Authorization"];
        //    SetConfiguration(context);
        //    AuthorizedModel? authorized = null;
        //    string message = "Unauthorized";
        //    try
        //    {
        //        authorized = _loginService.ValidateLoginAsync(authHeader).Result;
        //        bool roleAuthorized = true;
        //        bool phoneAuthorized = true;
        //        if (_roles.Count > 0 && !_roles.Any(r => r == (EnumModel.Role)authorized.Role))
        //        {
        //            //role authorizing
        //            roleAuthorized = false;
        //            message += " - Unauthorized for this function!";
        //        }
        //        if (_requiredPhone && authorized.Phone == null)
        //        {
        //            //phone authorizing
        //            phoneAuthorized = false;
        //            message += " - Phone required";
        //        }
        //        isAuthorized = roleAuthorized && phoneAuthorized;
        //        if (!isAuthorized)
        //        {
        //            if (_roles.Count > 0)
        //            {
        //                message += " - Required Role(s): " + GetAlertRequiredRoles();
        //                if (authorized != null)
        //                {
        //                    message += " - Current role: " + authorized.Role.ToString();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        isAuthorized = false;
        //    }
        //    if (!isAuthorized)
        //    {

        //        context.Result = context.Result = new ObjectResult(message)
        //        {
        //            StatusCode = (int)HttpStatusCode.Unauthorized
        //        };
        //        return;
        //    }
        //}
        //private string GetAlertRequiredRoles()
        //{
        //    string result = "";
        //    foreach (var item in _roles)
        //    {
        //        result += item + ",";
        //    }
        //    result = result.Substring(0, result.Length - 1);
        //    return result;
        //}
    }
}