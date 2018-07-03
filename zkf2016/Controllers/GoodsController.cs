using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zkf2016.Controllers
{
    public class GoodsController : Controller
    {
        // GET: Goods
        //库存管理
        public ActionResult GIndex(string a)
        {
            var db = new AirDataBase();
            db.Database.CreateIfNotExists();

            var list = db.Goods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(a))
            {
                list = list.Where(o => o.GoodsName.Contains(a));
            }
            ViewBag.Goods = list.OrderByDescending(o => o.GoodsId).ToList();
            ViewBag.a = a;

            return View();
        }
        //采购管理
        public ActionResult GoodsBuy()
        {
            return View();
        }

        public ActionResult SellsSell()
        {
            return View();
        }

        public ActionResult GoodsBuySave(Goods1 model)//商品采购保存
        {

            if (ModelState.IsValid)
            {
                var article = new Goods1();

                article.GoodsName = model.GoodsName;
                article.GoodsBuyPrice = model.GoodsBuyPrice;
                article.GoodsSellPrice = model.GoodsSellPrice;
                article.GoodsNumber = model.GoodsNumber;
                article.GoodsBuyDate = DateTime.Now;

                var db = new AirDataBase();
             
                db.Goods.Add(article);
                db.SaveChanges();
            }

            return Redirect("GIndex");

        }

        public ActionResult Show(int id)
        {
            var db = new AirDataBase();
            var article = db.Goods.First(o => o.GoodsId == id);

            ViewData.Model = article;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var db = new AirDataBase();
            var article = db.Goods.First(o => o.GoodsId == id);

            ViewData.Model = article;
            return View();
        }

        public ActionResult EditSave(int id, string name, string buyprice, string sellprice, long number)
        {
            var db = new AirDataBase();
            var article = db.Goods.First(o => o.GoodsId == id);

            article.GoodsName = name;
            article.GoodsBuyPrice = buyprice;
            article.GoodsSellPrice = sellprice;
            article.GoodsNumber = number;


            db.SaveChanges();

            return RedirectToAction("GIndex");
        }
        //商品出售

        public ActionResult SellSave(Goods1 model)
        {
            if (ModelState.IsValid)
            {
                var db = new AirDataBase();
                db.Database.CreateIfNotExists();

                var lst = db.Goods.AsQueryable();
                lst = lst.Where(o => o.GoodsName.Contains(model.GoodsName));
                foreach (var a in lst)
                {
                    if (a.GoodsName == model.GoodsName)
                    {
                        a.GoodsNumber = a.GoodsNumber - model.GoodsNumber;
                    }
                   
                }
            }
          
               // return RedirectToAction("Index", "Home");      
        return Redirect("GIndex");
        }

        public ActionResult Delete(int id)
        {
            var db = new AirDataBase();
            var article = db.Goods.First(o => o.GoodsId == id);

            db.Goods.Remove(article);
            db.SaveChanges();

            return RedirectToAction("GIndex");
        }



    }
}