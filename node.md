## 项目简单说明


### Nuget
- session 依赖
  - Microsoft.AspNetcore.session 

### Startup.cs  --Session设置
- public void ConfigureServices(IServiceCollection services)
```
services.AddMvc();
// session 设置
services.AddSession(options =>
{
    // 设置 Session 过期时间
    options.IdleTimeout = TimeSpan.FromDays(90);
    options.CookieHttpOnly = true;
});
```
### 登陆 Session 设置
- Controllers -> LoginController.cs
```
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
```
### 登录基类
- 需要验证的继承与该类即可
- Models -> LoginControllerBase.cs
```
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
```