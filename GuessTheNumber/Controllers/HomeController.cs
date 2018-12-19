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
            char[] arr_vle = vle.ToCharArray();
            char[] arr_secret = secret.ToCharArray();

            for (var i = 0; i <= 3; i++)
            {
                if (arr_vle[i] == arr_secret[i])
                {
                    res = res + "B";
                }
                else
                {
                    res = res + arr_vle[i];
                }
            }

            char[] arr_res = res.ToCharArray();
            for (var i = 0; i <= 3; i++)
            {
                if (arr_res[i].ToString() != "B")
                {
                    if (res.Contains(arr_secret[i]))
                    {
                        res = res.Replace(arr_secret[i].ToString(), "K");
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