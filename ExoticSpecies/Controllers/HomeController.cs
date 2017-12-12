/*
    Author: Alex Yoo
    Content: Homepage. Only use Index view.
    Usage: ~/Home
*/
using ExoticSpeciesOfTheNorth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExoticSpeciesOfTheNorth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(bool notifyUsers = false)
        {
            ViewBag.NotifyUsers = notifyUsers;

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