using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        }

        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=thad_donaghue_test;";
        }

        [TestMethod]
        public void Find_FindsClientInDatabase()
        {
            Client testClient = new Client("Moe", 0);
            testClient.Save();

            Client foundClient = Client.Find(testClient.Id);

            Assert.AreEqual(testClient, foundClient);
        }

        [TestMethod]
        public void GetAll_ReturnsAListOfClientObjects()
        {
            CollectionAssert.AllItemsAreNotNull(Client.GetAll());
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToClient_Id()
        {
            Client testClient = new Client("Moe", 0);
            testClient.Save();

            Client savedClient = Client.GetAll()[0];

            int result = savedClient.Id;
            int testId = testClient.Id;

            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
        {
            Client firstClient = new Client("Mow the lawn", 0);
            Client secondClient = new Client("Mow the lawn", 0);

            Assert.AreEqual(firstClient, secondClient);
        }
    }
}
