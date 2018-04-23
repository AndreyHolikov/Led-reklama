using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Led.WEB;
using Led.WEB.Controllers;
using Moq;
using Led.BLL;
using Led.BLL.Interfaces;
using Led.WEB.Models;
using Led.BLL.DTO;
using AutoMapper;
using System.Web.Mvc;
using Led.DAL.Interfaces;
using Led.DAL.Repositories;

namespace Led.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewModelNotNull()
        {
            //IDisplayService serv, IMapper mapper)
            // Arrange
            var mockDisplayService = new Mock<IDisplayService>();
            mockDisplayService.Setup(a => a.GetAll()).Returns(new List<DisplayDTO>() { new DisplayDTO() { Id = 1, Name = "name"} });

            var mockMapperService = new Mock<IMapper>();
            mockMapperService.Setup(a => a.ServiceCtor);

            HomeController controller = new HomeController(mockDisplayService.Object, mockMapperService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
           // Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            //Assert.AreEqual("Hello world!", result.ViewBag.Message);
            //Assert.IsNotNull(result.ViewBag.Displays);
        }

        //[TestMethod]
        //public void HomeController_Index_NotNull()
        //{
        //    // Arrange
        //    //var mock = new Mock<IRepository<Address>>();
        //    //mock.Setup(a => a.GetAll()).Returns(new List<Address>());
        //    IUnitOfWork unitOfWork = new EFUnitOfWork(@"Data Source=PC-631\SQLEXPRESS;Initial Catalog=LedCatalog_18042018_DB;Integrated Security=True");
        //    HomeController controller = new HomeController(unitOfWork);// mock.Object);

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void IndexViewBagMessage()
        //{
            // Arrange
            //var mock = new Mock<IRepository<Address>>();
            //mock.Setup(a => a.GetAll()).Returns(new List<Address>());
            //HomeController controller = new HomeController(mock.Object);

            //HomeController controller = new HomeController(new AddressService(new EFUnitOfWork(@"Data Source=PC-631\SQLEXPRESS;Initial Catalog=LedCatalog_04042018_DB;Integrated Security=True")));
            //string expected = "В базе данных 1 объект";

            // Act
            //ViewResult result = controller.Index() as ViewResult;
            //string actual = result.ViewBag.Message as string;

            // Assert
            //Assert.AreEqual(expected, actual);
        //}


        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
