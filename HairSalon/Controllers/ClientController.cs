using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/new-client")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet("/view-all-clients")]
        public ActionResult ViewAll()
        {
            return View(Client.GetAll());
        }

        [HttpPost("/view-all-clients")]
        public ActionResult ViewAllPost()
        {
            string name = Request.Form["name"];

            Client newClient = new Client(name);
            newClient.Save();

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

        [HttpGet("/stylist/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Stylist deleteStylist = Stylist.Find(id);
            deleteStylist.Delete();

            return RedirectToAction("ViewAll");
        }
    }
}