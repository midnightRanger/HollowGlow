using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using HollowGlow.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using HollowGlow.blockchain;
using HollowGlow.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HollowGlow.Controllers
{
    public class MainController : Controller
    {

        private ApplicationContext db;
        private IWebHostEnvironment _app;
        public MainController(ApplicationContext context, IWebHostEnvironment app)
        {
            db = context;
            _app = app;

        }
        //GET: MainController
        public ActionResult MainView(UserModel user)
        {
            var viewmodel = new ClickerViewModel();
            var income = user.Grades.Select(grade => grade.Income.GetValueOrDefault()).Sum();

            if (income == 0) viewmodel.Income = 1; else viewmodel.Income = income;
            viewmodel.User = user;
            return View(viewmodel);
        }

        public async Task<ActionResult> BlocksView(BlockModel blockModel)
        {
            var blockModels = await db.Blocks
                .Include(block => block.User)
                .ToListAsync();
            return View(blockModels);
        }

        [HttpPost]
        public async Task<ActionResult> Craft(BlockModel blockModel)
        {
            int id = Convert.ToInt32(Request.Cookies["id"]);

            BlockModel prevblockModel = db.Blocks.OrderByDescending(x => x.Id).FirstOrDefault();
            string prevHash = prevblockModel.Hash;

            var block = Blockchain.CreateBlock(id, "Simple Sword", prevHash);
            db.Blocks.Add(block);
            await db.SaveChangesAsync();

            return View("CraftView");

        }

        [HttpGet]
        public async Task<ActionResult> ShopView()
        {
            int id = Convert.ToInt32(Request.Cookies["id"]);

            var grades = await db.BuildingGrades
                .Include(grade => grade.Building)
                .ThenInclude(building => building.Type)
                .ToListAsync();

            //ViewBag.MinerLvl = 1;
            //ViewBag.MainBuildingLvl = 1;
            //ViewBag.DefenseLvl = 1;

            var user = await db.Users.FirstOrDefaultAsync(user => user.Id == id);
            List<BuildingGradesModel> ownedGradesList = user.Grades;


            //var ownedGrades = db.BuildingGrades.SelectMany(bg => bg.Buyers.Where(bu => bu.Id == id)).ToArray();

            //var ownedGrades = db.Users.SelectMany(bg => bg.Grades.Where(bu => bu.Buyers.Where(buy => buy.Id == id))).ToArray(); 

            //var ownedGrades = db.BuildingGrades.Include(c => user.Grades.Where(gr => gr.Buyers == ).ToArray();

            BuildingGradesModel[] ownedGrades = user.Grades.ToArray();
            //var upgradeShop = await db.UpgradesShop.ToListAsync<UpgradesShopModel>();

            //var toBuy = await db.BuildingGrades.Select(gr => ownedGrades.Where(og => og.Id == gr.Id)).ToListAsync<BuildingGradesModel>();

           

            return View();
        }

        public async Task<ActionResult> CraftView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int? itemId)
        {
            int id = Convert.ToInt32(Request.Cookies["id"]);
            var user = await db.Users.FirstOrDefaultAsync(user => user.Id == id);

            var grade = await db.BuildingGrades.FirstOrDefaultAsync(grades => grades.Id == itemId);

            user.Coins -= grade.Cost;


            BuildingGradesModel gradeUser = user.Grades.FirstOrDefault(grade => grade.BuildingId == grade.BuildingId);

            if (gradeUser == null)
            {
                user.Grades.Add(grade);
            }
            else
            {
                user.Grades.Remove(gradeUser);
                user.Grades.Add(grade);
            }
            db.Users.Update(user);
            await db.SaveChangesAsync();

            return View("ShopView");
        }

        [HttpPost]
        public async Task<ActionResult> LoadCoins(UserModel user)
        {
            int id = Convert.ToInt32(Request.Cookies["id"]);
            int coins = Convert.ToInt32(Request.Cookies["coins"]);
            user = await db.Users.FirstOrDefaultAsync(user => user.Id == id);


            user.Coins += coins;
            db.Users.Update(user);

            await db.SaveChangesAsync();
            return RedirectToAction("MainView", user);

        }
    }
}
