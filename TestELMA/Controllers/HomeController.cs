using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestELMA.Models;

namespace TestELMA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            using (var client = new WebClient()) 
            using (var stream = client.OpenRead("https://www.cbr-xml-daily.ru/daily_json.js"))
            using (var sr = new StreamReader(stream))
            {
                string text = sr.ReadToEnd();
                JObject o = JObject.Parse(text);
                var a = o["Valute"].Children();
                foreach (var item in a)
                {
                    SelectListItem item1 = new SelectListItem { Text = item.First["CharCode"].ToString(), Value = item.First["CharCode"].ToString() };
                    selectListItems.Add(item1);
                }
            }
            SelectList b = new SelectList(selectListItems, "Value", "Text");
            ViewBag.List = b;
            return View();
        }
        public ActionResult Update(string name)
        {
            if(name != null)
            {
                ModelView model = new ModelView();
                using (var client = new WebClient())
                using (var stream = client.OpenRead("https://www.cbr-xml-daily.ru/daily_json.js"))
                using (var sr = new StreamReader(stream))
                {
                    string text = sr.ReadToEnd();
                    JObject o = JObject.Parse(text);
                    var a = o["Valute"][name];
                    model = a.ToObject<ModelView>();
                }
                return PartialView(model);
            }
            else
            {
                return View("Index");
            }
        }
    }
}