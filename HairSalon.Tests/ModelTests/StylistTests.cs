using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests.ModelsTests
{

    [TestClass]
    public class Stylist_Test : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        public Stylist_Test()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=thad_donaghue_test;";
        }

        [TestMethod]
        public void GetAll_StylistsEmptyAtFirst_0()
        {
            int result = Stylist.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForSameName_Stylist()
        {
            Stylist firstClass = new Stylist("Warrior", 0);
            Stylist secondClass = new Stylist("Warrior", 0);

            Assert.AreEqual(firstClass, secondClass);
        }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
            Stylist testClass = new Stylist("Mage", 0);
            testClass.Save();

            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist> { testClass };

            CollectionAssert.AreEqual(testList, result);
        }


        [TestMethod]
        public void Save_DatabaseAssignsIdToStylist_Id()
        {
            Stylist testClass = new Stylist("Hunter", 0);
            testClass.Save();

            Stylist savedClass = Stylist.GetAll()[0];

            int result = savedClass.Id;
            int testId = testClass.Id;

            Assert.AreEqual(testId, result);
        }


        [TestMethod]
        public void Find_FindsStylistInDatabase_Stylist()
        {
            Stylist testClass = new Stylist("Warlock", 0);
            testClass.Save();

            Stylist foundClass = Stylist.Find(testClass.Id);

            Assert.AreEqual(testClass, foundClass);
        }

        [TestMethod]
        public void GetClients_FindsAllClientsInDatabase_ClientList()
        {
            Stylist testClass = new Stylist("Warlock", 0);
            testClass.Save();

            Client testClient = new Client("Betty");
            testClient.Save();

            testClass.AddClient(testClient);

            Assert.AreEqual(testClient, testClass.GetClients()[0]);
        }

        [TestMethod]
        public void GetSpecialties_FindsAllSpecialtiesInDatabase_SpecialtyList()
        {
            Stylist testClass = new Stylist("Warlock", 0);
            testClass.Save();

            Specialty testSpecialty = new Specialty("Cuts");
            testSpecialty.Save();

            testClass.AddSpecialty(testSpecialty);

            Assert.AreEqual(testSpecialty, testClass.GetSpecialties()[0]);
        }

        [TestMethod]
        public void AddClient_LinksStylistWithClient_Stylist()
        {
            Stylist testClass = new Stylist("Warlock", 0);
            testClass.Save();

            Client testClient = new Client("Betty");
            testClient.Save();

            testClass.AddClient(testClient);

            Assert.AreEqual(testClient, testClass.GetClients()[0]);
        }

        [TestMethod]
        public void RemoveClient_UnLinksStylistWithClient_Stylist()
        {
            Stylist testClass = new Stylist("Warlock");
            testClass.Save();

            Client testClient = new Client("Betty");
            testClient.Save();

            testClass.AddClient(testClient);

            testClass.RemoveClient(testClient);

            Assert.AreEqual(0, testClass.GetClients().Count);
        }

        [TestMethod]
        public void RemoveSpecialty_UnLinksStylistWithSpecialty_Stylist()
        {
            Stylist testClass = new Stylist("Warlock");
            testClass.Save();

            Specialty testSpecialty = new Specialty("Cuts");
            testSpecialty.Save();

            testClass.AddSpecialty(testSpecialty);

            testClass.RemoveSpecialty(testSpecialty);

            Assert.AreEqual(0, testClass.GetSpecialties().Count);
        }
    }
}
