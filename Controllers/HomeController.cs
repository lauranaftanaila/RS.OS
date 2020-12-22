using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using RS.TreeView.Models;

namespace RS.TreeView.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            List<CategoryVW> Category = new List<CategoryVW>();

            XmlDocument docxml = new XmlDocument();

            docxml.Load(Server.MapPath("~/App_Data/Reports.xml"));

            XmlNodeList usernodes = docxml.SelectNodes("Reports/Categories/Category");

            CategoryVW cat;
            foreach (XmlNode c in usernodes)
            {
                cat = new CategoryVW();
                cat.Id = Convert.ToInt32(c.Attributes["id"].Value);
                cat.Category = c.Attributes["name"].Value;
                cat.IsCategory = true;
                foreach (XmlNode r in c.SelectNodes("Report"))
                {
                    cat.ReportVW.Add(new ReportVW
                    {
                        ReportId = int.Parse(r.Attributes["id"].Value),
                        Report = r.Attributes["name"].Value,
                        IsReport = true
                    }); ;
                }
                Category.Add(cat);

            }
            return View("Index", Category);
        }

        [HttpPost]
        public ActionResult Index(List<CategoryVW> Category)
        {
            List<CategoryVW> selectedCategory = Category.Where(a => a.IsCategory).ToList();
            List<ReportVW> selectedReport = Category.Where(a => a.IsCategory)
                                              .SelectMany(a => a.ReportVW.Where(b => b.IsReport)).ToList();
            return View();
        }
    


    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}