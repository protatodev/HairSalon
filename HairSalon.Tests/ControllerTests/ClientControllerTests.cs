using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests.ControllerTests
{
    [TestClass]
    public class ClientControllerTest
    {
        [TestMethod]
        public void Create_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();

            ActionResult createView = controller.Create();

            Assert.IsInstanceOfType(createView, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();

            ActionResult detailsView = controller.Details(1);

            Assert.IsInstanceOfType(detailsView, typeof(ViewResult));
        }

        [TestMethod]
        public void Update_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();

            ActionResult updateView = controller.Update(1);

            Assert.IsInstanceOfType(updateView, typeof(ViewResult));
        }

        [TestMethod]
        public void ViewAll_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();

            ActionResult viewAllView = controller.ViewAll();

            Assert.IsInstanceOfType(viewAllView, typeof(ViewResult));
        }
    }
}