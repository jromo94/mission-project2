using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Section 2 Group 8
// Josue Romo, Jordan Holzer, Andrew Schwartz, Tanner Morse 
//This project is a missionary FAQ page that allows someone who is going on a mission get some of their questions answered
// the user must sign in before being able look at the missions page and posting things

namespace MissionaryWebsiteP2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About()//this is about page
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //this lets you select subject
        public ActionResult Contact()
        {
            List<SelectListItem> subjects = new List<SelectListItem>();
            subjects.Add(new SelectListItem { Text = "one", Value = "0" });
            subjects.Add(new SelectListItem { Text = "two", Value = "1" });
            subjects.Add(new SelectListItem { Text = "three", Value = "2" });
            ViewBag.subjects = subjects;

            ViewBag.Message = "Your contact page.";

            ViewBag.Subject = "Subject";

            return View();

        }

        public ActionResult updateSubject()
        {
            ViewBag.Subject = "One";

            return View();
        }
    }
}