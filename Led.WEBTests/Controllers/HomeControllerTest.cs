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
using Led.WEB.Mapping;
using Led.BLL.Mapping;
using Led.WEB.Util;
using Led.WEB.Tests.Util;

namespace Led.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;
        private ViewResult result;

        [TestInitialize]
        public void SetupContext()
        {
            // Arrange / organization
            var mockDisplayService = new Mock<IDisplayService>();
            mockDisplayService.Setup(x => x.GetAll()).Returns(new List<DisplayDTO>{
              new DisplayDTO{ Id = 1, Name="User#1", Address="Address", Label="lb", Image="", Owner=""},
              new DisplayDTO{ Id = 2, Name="User#2", Address="Address", Label="lb", Image="", Owner=""},
              new DisplayDTO{ Id = 3, Name="User#3", Address="Address", Label="lb", Image="", Owner=""},
              new DisplayDTO{ Id = 4, Name="User#4", Address="Address", Label="lb", Image="", Owner=""}
            });

            // var mapper = config.CreateMapper();
            // or
            IMapper mapper = new Mapper( (new MapperConf()).CreateConfiguration() );

            controller = new HomeController(mockDisplayService.Object, mapper); 

            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m => m.Map<Foo, Bar>(It.IsAny<Foo>())).Returns(new Bar());
        }

        [TestMethod]
        public void Index_ViewModelNotNull()
        {
            // Arrange

            // Act / action
            result = controller.Index() as ViewResult;

            // Assert 
            Assert.IsNotNull(result.ViewBag.Displays);
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
