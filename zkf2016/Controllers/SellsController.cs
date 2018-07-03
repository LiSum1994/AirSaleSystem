using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zkf2016.Controllers
{
    public class SellsController : Controller
    {
        // GET: Sells

        public ActionResult SellsSell()
        {
           // if (Request.Cookies["isauth"] != null && Request.Cookies["isauth"].Value == "true")
           // {
                return View();
          //  }
           // else
           // {
           //     return RedirectToAction("login", "cookiedemo");
          //  }
        }

        public ActionResult SellsSellSave(Sell model)//商品销售保存
        {

            if (ModelState.IsValid)
            {
                var db = new AirDataBase();
                db.Database.CreateIfNotExists();

                var sellssell = new Sell();
                sellssell.SellsName = model.SellsName;
                sellssell.SellsSellPrice = model.SellsSellPrice;
                sellssell.SellsNumber = model.SellsNumber;
                sellssell.SellsSellDate = DateTime.Now;

                db.Sells.Add(sellssell);
                db.SaveChanges();
            }

            return Redirect ("SellsSell");

        }
    }
}