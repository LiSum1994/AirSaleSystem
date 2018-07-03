using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zkf2016.Controllers
{
    public class SysAdminController : Controller
    {
        // GET: SysAdmin
        public ActionResult SysIndex()      //用户登录主页
        {
            
            return View();
        }


        public ActionResult SysLogin(User1 model)      //用户登录主页
        {
            var state = false;
            if (ModelState.IsValid)
            {
                var db = new AirDataBase();
                db.Database.CreateIfNotExists();

                var lst = db.User.AsQueryable();
                lst = lst.Where(o => o.UserName.Contains(model.UserName));
                foreach (var a in lst)
                {
                    if (a.UserName == model.UserName && a.UserPassword == model.UserPassword)
                    {
                        state = true;
                    }
                    else state = false;
                }
            }
            if (state == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else return Redirect("SysIndex");

        }

        public ActionResult SysAdminRegister()      //用户注册
        {
            return View();
        }

        public ActionResult SysAdminRegisterSave(User1 model)       //用户注册保存
        {

            if (ModelState.IsValid)
                {
                    var db = new AirDataBase();
                    db.Database.CreateIfNotExists();

                    var sysAdminRegister = new User1();
                    sysAdminRegister.UserName = model.UserName;
                    sysAdminRegister.UserPassword = model.UserPassword;

                    db.User.Add(sysAdminRegister);
                    db.SaveChanges();
                }
            
                return Redirect("SysIndex");
               

        }
    }
}