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
        public async Task<ActionResult> LoginEnter(UserModel user)
        {
            if (user != null)
            {
                UserModel users = db.Users.FirstOrDefault(predicate => predicate.Email == user.Email && predicate.Password == user.Password);
                if (users != null)
                {
                    UpgradesModel upgrades = db.Upgrades.FirstOrDefault(predicate => predicate.UserId == users.Id);

                    if (upgrades == null)
                    {
                        upgrades = new UpgradesModel() { MainBuilding = 0, Miner = 0, Defence = 0, UserId = users.Id, user = users };
                        db.Upgrades.Add(upgrades);

                        users.UpgradesModel = upgrades; 
                        db.Users.Update(users);
                        await db.SaveChangesAsync();
                    }

                    Blockchain blockchain = new Blockchain();
                    //blockchain.AddBlock("", users.Id,db);


                    
                    int i = 0;
                    foreach (BlockModel blc in Blockchain.blockchain)
                    {
                        System.Diagnostics.Debug.WriteLine("{0}, {1}, {2}, {3}, {4}", i, blc.Data, blc.Hash, blc.Timestamp, blc.Nonce);
                        i++;
                    }

                    Response.Cookies.Append("id", users.Id.ToString());
                    Response.Cookies.Append("role", users.Role.ToString());
                    
                    return RedirectToAction("MainView", "Main", users);
                }
                else
                {
                    ModelState.AddModelError("Error", "Неверный логин или пароль.");
                }
            }

            return View("LoginView");



        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
