using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet("/specialty/add")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet("/specialties")]
        public ActionResult ViewAll()
        {
            return View(Specialty.GetAll());
        }

        [HttpPost("/specialties")]
        public ActionResult ViewAllPost()
        {
            string name = Request.Form["name"];

            Specialty newSpecialty = new Specialty(name);
            newSpecialty.Save();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/specialty/{id}/update")]
        public ActionResult Update(int id)
        {
            Specialty editSpecialty = Specialty.Find(id);

            return View(editSpecialty);
        }

        [HttpPost("/specialty/{id}/update")]
        public ActionResult UpdatePost(int id)
        {
            Specialty editSpecialty = Specialty.Find(id);
            string name = Request.Form["new-name"];
            editSpecialty.Edit(name);

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/specialty/{id}/details")]
        public ActionResult Details(int id)
        {
            Specialty specialtyDetails = Specialty.Find(id);

            return View(specialtyDetails);
        }

        [HttpGet("/specialty/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Specialty deleteSpecialty = Specialty.Find(id);
            deleteSpecialty.Delete();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/specialty/delete")]
        public ActionResult DeleteAll()
        {
            Specialty.DeleteAll();

            return RedirectToAction("ViewAll");
        }
    }
}