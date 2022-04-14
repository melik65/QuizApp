using MelikCirak.BusinessLayer.Concrete;
using MelikCirak.DataAcessLayer.EntityFramework;
using MelikCirak.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MelikCirak.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private UserManager userManager;
        public LoginController()
        {
            userManager = new UserManager(new EfUserRepository());
        }
        [HttpGet]
        public IActionResult UserLogin()
        {
            if (HttpContext.Session.GetInt32("user") != null)
            {
                //if user is already login then redirect to quiz page
                return Redirect("/quiz");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(User _user)
        {
            //checking user
            var user = userManager.Get(x => x.Mail.Equals(_user.Mail) && x.Password.Equals(_user.Password));

            if (user == null)
            {
                ViewBag.error = "kullanıcı adı veya şifre hatalı";
                return View(_user);
            }
            //creating session to user id
            HttpContext.Session.SetInt32("user", user.Id);

            var claims = new List<Claim>
             {
                new Claim(ClaimTypes.Name,user.Mail)
             };
            var userIdentity = new ClaimsIdentity(claims, "a");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);            
            return Redirect("/quiz");

        }

    }
}
