using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.ViewModels;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        [HttpGet("/stylist/add")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet("/stylists")]
        public ActionResult ViewAll()
        {
            return View(Stylist.GetAll());
        }

        [HttpPost("/stylists")]
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
            StylistViewModel viewModel = new StylistViewModel(editStylist);

            return View(viewModel);
        }

        [HttpPost("/stylist/{id}/update")]
        public ActionResult UpdatePost(int id, int newClientId, int newSpecialtyId)
        {
            Stylist editStylist = Stylist.Find(id);
            string name = Request.Form["new-name"];
            int experience = int.Parse(Request.Form["new-exp"]);
            editStylist.Edit(name, experience);

            if(newClientId > 0)
            {
                Client newClient = Client.Find(newClientId);
                editStylist.AddClient(newClient);
            }

            if (newSpecialtyId > 0)
            {
                Specialty newSpecialty = Specialty.Find(newSpecialtyId);
                editStylist.AddSpecialty(newSpecialty);
            }

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

        [HttpGet("/stylists/delete")]
        public ActionResult DeleteAll()
        {
            Stylist.DeleteAll();

            return RedirectToAction("ViewAll");
        }
    }
}