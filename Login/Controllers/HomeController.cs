using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    // 继承与 LOginControllerBase 实现登录时检查用户是否登陆
    public class HomeController : LoginControllerBase
    {
        private LoginDbContext _LoginDbContext;

        public HomeController(LoginDbContext LoginDbContext) : base(LoginDbContext)
        {
            _LoginDbContext = LoginDbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            // 获取cookie
            HttpContext.Session.TryGetValue("UserId", out byte[] result);
            var userId = System.Text.Encoding.UTF8.GetString(result);

             var user = _LoginDbContext.Users.Single(u => u.UsersId.ToString() == userId);
            return View(user);
        }
    }
}
