using HollowGlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using HollowGlow.blockchain;
using Microsoft.EntityFrameworkCore;

namespace HollowGlow.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        private IWebHostEnvironment _app;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationContext context, IWebHostEnvironment app)
        {
            db = context;
            _app = app;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RegisterView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterRedirect()
        {
            return RedirectToAction("RegisterView");
        }

        [HttpPost]
        public async Task<ActionResult> RegisterEnter(UserModel user)
        {
            UserModel users = db.Users.FirstOrDefault(predicate => predicate.Email == user.Email && predicate.Password == user.Password);

            if (users == null)
            {
                user.Role = 0; //Standard 
                user.Coins = 0;

                

                db.Users.Add(user);

                await db.SaveChangesAsync();



                return RedirectToAction("LoginView");
            }
            else
                return RedirectToAction("Privacy");
        }


        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginEnter(UserModel user)
        {
            UserModel authorizing = db.Users
                .Include(user => user.Blocks)
                .Include(user => user.Grades)
                .ThenInclude(grade => grade.Building)
                .ThenInclude(build => build.Type)
                .FirstOrDefault(predicate => predicate.Email == user.Email && predicate.Password == user.Password);

            if (authorizing == null)
            {
                ModelState.AddModelError("Error", "Неверный логин или пароль.");
                return View(nameof(LoginView));
            }

            int i = 0;
            foreach (BlockModel blc in Blockchain.blockchain)
            {
                Debug.WriteLine($"{i}, {blc.Data}, {blc.Hash}, {blc.Timestamp}, {blc.Nonce}");
                i++;
            }

            Response.Cookies.Append("id", authorizing.Id.ToString());
            Response.Cookies.Append("role", authorizing.Role.ToString());

            

            return RedirectToAction("MainView", "Main", authorizing);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
