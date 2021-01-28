using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.MVC.Controllers
{
    public class ContaController : Controller
    {
        [Authorize]
        public async Task<ActionResult> Login()
        {
            return Redirect(Url.Content("~/"));
        }
        [Authorize]
        public async Task Logout()
        {
            //atualizar os cookies 
            await HttpContext.SignOutAsync("Cookies");
            //Sign out(Desconeção) no IdentityServer
            await HttpContext.SignOutAsync("OpenIdConnect");
            
        }
    }
}