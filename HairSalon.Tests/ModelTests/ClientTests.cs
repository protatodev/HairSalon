﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests.ModelsTests
{
    [TestClass]
    public class ClientTests
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=thad_donaghue_test;";
        }

        [TestMethod]
        public void GetAll_ClientsEmptyAtFirst_0()
        {
            int result = Client.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
        {
            Client firstClient = new Client("Mow the lawn");
            Client secondClient = new Client("Mow the lawn");

            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void Save_SavesClientToDatabase_ClientList()
        {
            Client testClient = new Client("Mage");
            testClient.Save();

            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client> { testClient };

            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToClient_Id()
        {
            Client testClient = new Client("Ron");
            testClient.Save();

            Client savedClient = Client.GetAll()[0];

            int result = savedClient.Id;
            int testId = testClient.Id;

            Assert.AreEqual(testId, result + 1);
        }

        [TestMethod]
        public void Find_FindsClientInDatabase_Client()
        {
            Client testClient = new Client("Moe");
            testClient.Save();

            Client foundClient = Client.Find(testClient.Id);

            Assert.AreEqual(testClient, foundClient);
        }

        [TestMethod]
        public void GetStylists_FindsAllStylistsInDatabase_StylistList()
        {
            Client testClass = new Client("Cuts");
            testClass.Save();

            Stylist testStylist = new Stylist("Betty");
            testStylist.Save();

            testClass.AddStylist(testStylist);

            Assert.AreEqual(testStylist, testClass.GetStylists()[0]);
        }

        [TestMethod]
        public void AddStylist_LinksSpecialtyWithStylist_Specialty()
        {
            Client testClass = new Client("Warlock");
            testClass.Save();

            Stylist testStylist = new Stylist("Betty");
            testStylist.Save();

            testClass.AddStylist(testStylist);

            Assert.AreEqual(testStylist, testClass.GetStylists()[0]);
        }
    }
}
