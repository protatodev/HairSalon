using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        [HttpGet("/new-stylist")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet("/view-all-stylists")]
        public ActionResult ViewAll()
        {
            return View(Stylist.GetAll());
        }

        [HttpPost("/view-all-stylists")]
        public ActionResult ViewAllPost()
        {
            string name = Request.Form["name"];
            int experience = int.Parse(Request.Form["experience"]);

            Stylist newStylist = new Stylist(name, 0, experience);
            newStylist.Save();

            return RedirectToAction("ViewAll");
        }

    }
}