using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetAdoptionApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;
        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Secret()
        {
            return View();
        }

        [HttpPost]
        public async  Task<ActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                //sign in
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false );

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Register(string username, string email, string password)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = email,
            };
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                //sign user herre
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Authenticate()
        {
            return RedirectToAction("Index");
        }
    }
}
