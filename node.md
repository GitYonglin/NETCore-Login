## ��Ŀ��˵��


### Nuget
- session ����
  - Microsoft.AspNetcore.session 

### Startup.cs  --Session����
- public void ConfigureServices(IServiceCollection services)
```
services.AddMvc();
// session ����
services.AddSession(options =>
{
    // ���� Session ����ʱ��
    options.IdleTimeout = TimeSpan.FromDays(90);
    options.CookieHttpOnly = true;
});
```
### ��½ Session ����
- Controllers -> LoginController.cs
```
/// <summary>
/// ��¼��֤
/// </summary>
/// <param name="u">�û� model ����</param>
/// <returns></returns>
[HttpPost]
public IActionResult Index(User u)
{
    if (u != null)
    {
        var user = _LoginDbContext.Users.FirstOrDefault(it => it.UserName == u.UserName && it.Password == u.Password);
        if (user != null)
        {
            // ���� Session 
            HttpContext.Session.SetString("UserId", user.UsersId.ToString());
            return RedirectToAction("Index", "Home");
        }
    }
    ViewData["msg"] = "�û������������!!";
    return View();
}
```
### ��¼����
- ��Ҫ��֤�ļ̳�����༴��
- Models -> LoginControllerBase.cs
```
public override void OnActionExecuting(ActionExecutingContext loigncontext)
{
    loigncontext.HttpContext.Session.TryGetValue("UserId", out byte[] result);
    // û�� session �����ʱ��ת����ҳ��
    if (result == null)
    {
        loigncontext.Result = new RedirectResult("/Login/Index");
        return;
    }
    else
    {
        // session���жϿ����߼�
    }
    base.OnActionExecuting(loigncontext);
}
```