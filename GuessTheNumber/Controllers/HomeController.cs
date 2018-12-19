using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessTheNumber.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public JsonResult GetSecret()
        {
            Random rnd = new Random();
            int n = rnd.Next(0, 9999);
            string res = n.ToString("D4");
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckSecret(string vle, string secret)
        {
            string res = string.Empty;
            vle = Convert.ToInt32(vle).ToString("D4");
            var arrVle = vle.ToCharArray();
            var arrSecret = secret.ToCharArray();

            for (var i = 0; i <= 3; i++)
            {
                if (arrVle[i] == arrSecret[i])
                {
                    res = res + "B";
                }
                else
                {
                    res = res + arrVle[i];
                }
            }

            var arrRes = res.ToCharArray();
            for (var i = 0; i <= 3; i++)
            {
                if (arrRes[i].ToString() != "B")
                {
                    if (res.Contains(arrSecret[i]))
                    {
                        res = res.Replace(arrSecret[i].ToString(), "K");
                    }
                }
            }

                return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}