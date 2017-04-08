using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Models
{
    public class LoginControllerBase : Controller
    {
        // 数据库连接
        private LoginDbContext _LoginDbContext;
        public LoginControllerBase(LoginDbContext LoginDbContext)
        {
            _LoginDbContext = LoginDbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext loigncontext)
        {
            loigncontext.HttpContext.Session.TryGetValue("UserId", out byte[] result);
            // 没有 session 或过期时跳转到的页面
            if (result == null)
            {
                loigncontext.Result = new RedirectResult("/Login/Index");
                return;
            }
            else
            {
                // session的判断可以逻辑
            }
            base.OnActionExecuting(loigncontext);
        }
        /// <summary>
        /// 获取服务端验证的第一条错误信息
        /// </summary>
        /// <returns></returns>
        public string GetModelStateError()
        {
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    return item.Errors[0].ErrorMessage;
                }
            }
            return "";
        }
    }
}
