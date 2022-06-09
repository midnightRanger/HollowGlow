using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollowGlow.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using HollowGlow.blockchain;

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
            int id = Convert.ToInt32(Request.Cookies["id"]);

            user = db.Users.FirstOrDefault(predicate => predicate.Id == id);
            UpgradesModel upgrades = db.Upgrades.FirstOrDefault(predicate => predicate.UserId == user.Id);
            user.UpgradesModel = upgrades;

            return View(user);

        }

        public async Task<ActionResult> BlocksView(BlockModel blockModel)
        {
            var blockModels = await db.BlocksModel.ToListAsync<BlockModel>();
            return View(blockModels);
        }

        [HttpPost]
        public async Task<ActionResult> Craft(BlockModel blockModel)
        {
            int id = Convert.ToInt32(Request.Cookies["id"]);

            BlockModel prevblockModel = db.BlocksModel.OrderByDescending(x => x.Id).FirstOrDefault();
            string prevHash = prevblockModel.Hash; 

            Blockchain blockchain = new Blockchain();
            blockchain.AddBlock("", id, db,"Simple Sword", prevHash);

            db.SaveChangesAsync();

            return View("CraftView");

        }


        public async Task<ActionResult> ShopView(UpgradesShopModel upgradesShop)
        {
            int id = Convert.ToInt32(Request.Cookies["id"]);

            UpgradesModel upgrades;
            upgrades = await db.Upgrades.FirstOrDefaultAsync(upgrades => upgrades.UserId == id);

            var upgradeShop = await db.UpgradesShop.ToListAsync<UpgradesShopModel>();

            ViewBag.MinerLvl = upgrades.Miner;
            ViewBag.MainBuildingLvl = upgrades.MainBuilding;
            ViewBag.DefenseLvl = upgrades.Defence;

            return View(upgradeShop);
        }

        public async Task<ActionResult> CraftView()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Mine()
        {
            int id = Convert.ToInt32(Request.Cookies["id"]);
            int idItem = Convert.ToInt32(Request.Cookies["idItem"]);
            var  upgradeShops = await db.UpgradesShop.ToListAsync<UpgradesShopModel>();
 
            UpgradesModel upgrades = await db.Upgrades.FirstOrDefaultAsync(user => user.UserId == id);
            UserModel user = await db.Users.FirstOrDefaultAsync(user => user.Id == id);
            UpgradesShopModel upgradeShop = await db.UpgradesShop.FirstOrDefaultAsync(predicate => predicate.Id == idItem);

            if (upgradeShop != null)
            {
                if (user.Coins > upgradeShop.Cost)
                {
                    user.Coins -= upgradeShop.Cost;
                    upgrades.Miner = upgradeShop.Lvl;


                    ViewBag.BoughtId = upgradeShop.Id;

                    db.Upgrades.Update(upgrades);
                    db.Users.Update(user);
                    await db.SaveChangesAsync();
                    ModelState.AddModelError("Error", " Ок.");

                }

                else { ModelState.AddModelError("Error", " Ошибка. Недостаточно средств"); ViewBag.BadId = idItem; }

            }
            else ModelState.AddModelError("Error", " Ошибка. Предмет не найнден");
            return View("ShopView", upgradeShops);

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
