using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        private LoginDbContext _LoginDbContext;

        public LoginController(LoginDbContext LoginDbContext)
        {
            _LoginDbContext = LoginDbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //获取GUID
            //var guid = Guid.NewGuid();
            //string str = guid.ToString();
            //ViewData["msg"] = str;
            //var ps = Encryption("123456789");
            //ViewData["msg"] = ps.a;
            //ViewData["msg2"] = ps.b;
            //ViewData["msg3"] = ps.c;
            //ViewData["msg4"] = ps.d;

            return View();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="u">用户 model 数据</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(User u)
        {
            if (u != null)
            {
                var user = _LoginDbContext.Users.FirstOrDefault(it => it.UserName == u.UserName && it.Password == u.Password);
                if (user != null)
                {
                    // 设置 Session 
                    HttpContext.Session.SetString("UserId", user.UsersId.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewData["msg"] = "用户名或密码错误!!";
            return View();
        }


        
    }
}
