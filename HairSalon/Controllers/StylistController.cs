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
            int experience = int.Parse(Request.Form["exp"]);

            Stylist newStylist = new Stylist(name, 0, experience);
            newStylist.Save();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/stylist/{id}/update")]
        public ActionResult Update(int id)
        {
            Stylist editStylist = Stylist.Find(id);

            return View(editStylist);
        }

        [HttpPost("/stylist/{id}/update")]
        public ActionResult UpdatePost(int id)
        {
            Stylist editStylist = Stylist.Find(id);
            string name = Request.Form["new-name"];
            int experience = int.Parse(Request.Form["new-exp"]);

            editStylist.Edit(name, experience);

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/stylist/{id}/details")]
        public ActionResult Details(int id)
        {
            Stylist stylistDetails = Stylist.Find(id);

            return View(stylistDetails);
        }
    }
}