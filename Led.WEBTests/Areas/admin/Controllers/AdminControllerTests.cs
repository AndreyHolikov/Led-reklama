using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Led.DAL.Interfaces;
using Led.DAL.Repositories;
using Led.DAL.Entities;
using System.Web.Mvc;
using Led.WEB.Areas.Admin.Controllers;
using Led.BLL.Interfaces;
using Led.BLL.Services;
using Led.BLL.DTO;
using Moq;
using AutoMapper;
using Led.WEB.Mapping;
using Led.BLL.Mapping;
using Led.WEB.Tests.Util;
using Led.WEB.Models;

namespace Led.WEB.Areas.Admin.Controllers.Tests
{
    [TestClass]
    public class AdminControllerTests
    {
        protected Mock<IOwnerService> mockService;
        protected IMapper mapper;
        protected OwnerController controller;
        protected int id = 1;
        protected string expected = "Index";
        protected OwnerViewModel viewModel;
        protected OwnerDTO DTO;

        [TestMethod]
        protected void admin_Index_ModelNotNull()
        {
            //// Arrange
            //mockService.Setup(x => x.GetAll()).Returns(new List<OwnerDTO>{
            //  new OwnerDTO{ Id = 1, Name="1" },
            //  new OwnerDTO{ Id = 2, Name="2" },
            //  new OwnerDTO{ Id = 3, Name="3" },
            //  new OwnerDTO{ Id = 4, Name="4" }
            //});

            //controller = new OwnerController(mockService.Object, mapper);

            // Act / action
            var result = controller.Index() as ViewResult;

            // Assert 
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        protected void admin_Details_ModelNotNull()
        {
            //// Arrange
            //mockService.Setup(x => x.Get(id)).Returns(DTO);
            //controller = new OwnerController(mockService.Object, mapper);

            // Act / action
            var result = controller.Details(id) as ViewResult;

            // Assert 
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        protected void admin_CreatePostAction_ModelError()
        {
            //// arrange
            //this.expected = "Create";

            //mockService.Setup(x => x.Add(DTO));
            //controller = new OwnerController(mockService.Object, mapper);

            //controller.ModelState.AddModelError("Name", "Название не установлено");

            // act
            ViewResult result = controller.Create(viewModel) as ViewResult;
            
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }

        [TestMethod]
        protected void admin_CreatePostAction_RedirectToIndexView()
        {
            //// Arrange
            //mockService.Setup(x => x.Add(DTO));
            //controller = new OwnerController(mockService.Object, mapper);

            // Act
            RedirectToRouteResult result = controller.Create(viewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        protected void admin_EditGetAction_ViewModelNotNull()
        {
            //// Arrange
            //mockService.Setup(x => x.Get(id)).Returns(DTO);
            //controller = new OwnerController(mockService.Object, mapper);

            // Act / action
            var result = controller.Edit(id) as ViewResult;

            // Assert 
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        protected void admin_EditPostAction_RedirectToIndexView()
        {
            //// Arrange
            //mockService.Setup(x => x.Update(DTO));
            //controller = new OwnerController(mockService.Object, mapper);

            // Act
            RedirectToRouteResult result = controller.Edit(viewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        protected void admin_DeleteGetAction_ViewModelNotNull()
        {
            //// Arrange
            //mockService.Setup(x => x.Delete(id)).Returns(DTO);
            //controller = new OwnerController(mockService.Object, mapper);

            // Act / action
            var result = controller.Delete(id) as ViewResult;

            // Assert 
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        protected void admin_DeletePostAction_RedirectToIndexView()
        {
            //// Arrange
            //mockService.Setup(x => x.Get(id)).Returns(DTO);
            //controller = new OwnerController(mockService.Object, mapper);

            // Act / action
            RedirectToRouteResult result = controller.DeleteConfirmed(id) as RedirectToRouteResult;

            // Assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["Action"]);
        }
    }
}