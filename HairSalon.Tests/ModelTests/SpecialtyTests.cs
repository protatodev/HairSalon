using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests.ModelsTests
{

    [TestClass]
    public class Specialty_Test : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        public Specialty_Test()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=thad_donaghue_test;";
        }

        [TestMethod]
        public void GetAll_SpecialtiesEmptyAtFirst_0()
        {
            int result = Specialty.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForSameName_Specialty()
        {
            Specialty firstSpecialty = new Specialty("Cuts");
            Specialty secondSpecialty = new Specialty("Cuts");

            Assert.AreEqual(firstSpecialty, secondSpecialty);
        }

        [TestMethod]
        public void Save_SavesSpecialtyToDatabase_SpecialtyList()
        {
            Specialty testClass = new Specialty("Cuts");
            testClass.Save();

            List<Specialty> result = Specialty.GetAll();
            List<Specialty> testList = new List<Specialty> { testClass };

            CollectionAssert.AreEqual(testList, result);
        }


        [TestMethod]
        public void Save_DatabaseAssignsIdToSpecialty_Id()
        {
            Specialty testClass = new Specialty("Cuts");
            testClass.Save();

            Specialty savedClass = Specialty.GetAll()[0];

            int result = savedClass.Id;
            int testId = testClass.Id;

            Assert.AreEqual(testId, result);
        }


        [TestMethod]
        public void Find_FindsSpecialtyInDatabase_Specialty()
        {
            Specialty testClass = new Specialty("Cuts");
            testClass.Save();

            Specialty foundClass = Specialty.Find(testClass.Id);

            Assert.AreEqual(testClass, foundClass);
        }

        [TestMethod]
        public void GetStylists_FindsAllStylistsInDatabase_StylistList()
        {
            Specialty testSpecialty = new Specialty("Cuts");
            testSpecialty.Save();

            Stylist testStylist = new Stylist("Betty");
            testStylist.Save();

            testSpecialty.AddStylist(testStylist);

            Assert.AreEqual(testStylist, testSpecialty.GetStylists()[0]);
        }

        [TestMethod]
        public void AddStylist_LinksSpecialtyWithStylist_Specialty()
        {
            Specialty testClass = new Specialty("Warlock");
            testClass.Save();

            Stylist testStylist = new Stylist("Betty");
            testStylist.Save();

            testClass.AddStylist(testStylist);

            Assert.AreEqual(testStylist, testClass.GetStylists()[0]);
        }
    }
}
