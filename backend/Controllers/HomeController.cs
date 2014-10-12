using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using backend.Models;
using backend.ViewModel;

namespace backend.Controllers
{
    public class HomeController : Controller
    {

        private MSPetShop4Entities db = new MSPetShop4Entities();

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logon()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logon(LogonViewModel model)
        {
            var memberAccount = db.SystemUsers.FirstOrDefault(x => x.Account == model.Account);

            //驗證身份
            //CooKie
            if (ModelState.IsValid)
            {
                if (memberAccount != null && memberAccount.Password == model.Password)
                {

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        model.Account,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        model.Remember, //將管理者登入的Cookie設定成Session Cookie
                        memberAccount.ID.ToString(), //role

                        FormsAuthentication.FormsCookiePath); //取得form表單路徑
                    //建立加密的票
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    //將票加入Cookie
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    if (model.Remember == true)
                    {
                        cookie.Expires = DateTime.Now.AddYears(1);
                    }
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index","Categories");
                }
                ModelState.AddModelError("LogOnError", "請輸入正確的帳號或密碼");
            }
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}