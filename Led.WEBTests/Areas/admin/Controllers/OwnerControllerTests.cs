using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class OwnerControllerTests: BaseControllerTests
    {
        [TestInitialize]
        public void SetupContext()
        {
            // Arrange / organization
            this.mockService = new Mock<IOwnerService>();
            // var mapper = config.CreateMapper();
            // or
            this.mapper = new Mapper( (new MapperConf()).CreateConfiguration() );

            this.id = 1;
            this.expected = "Index";
            this.viewModel = new OwnerViewModel { Id = 1, Name = "1" };
            this.DTO = new OwnerDTO { Id = 1, Name = "1" };
        }

        [TestMethod]
        public void Index_ModelNotNull()
        {
            // Arrange
            mockService.Setup(x => x.GetAll()).Returns(new List<OwnerDTO>{
              new OwnerDTO{ Id = 1, Name="1" },
              new OwnerDTO{ Id = 2, Name="2" },
              new OwnerDTO{ Id = 3, Name="3" },
              new OwnerDTO{ Id = 4, Name="4" }
            });

            controller = new OwnerController(mockService.Object, mapper);

            admin_Index_ModelNotNull();
        }

        [TestMethod]
        public void Details_ModelNotNull()
        {
            // Arrange
            mockService.Setup(x => x.Get(id)).Returns(DTO);
            controller = new OwnerController(mockService.Object, mapper);

            admin_Details_ModelNotNull();
        }

        [TestMethod]
        public void CreatePostAction_ModelError()
        {
            // arrange
            this.expected = "Create";

            mockService.Setup(x => x.Add(DTO));
            controller = new OwnerController(mockService.Object, mapper);

            controller.ModelState.AddModelError("Name", "Название не установлено");

            admin_CreatePostAction_ModelError();
        }

        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            // Arrange
            mockService.Setup(x => x.Add(DTO));
            controller = new OwnerController(mockService.Object, mapper);

            admin_CreatePostAction_RedirectToIndexView();
        }

        [TestMethod]
        public void EditGetAction_ViewModelNotNull()
        {
            // Arrange
            mockService.Setup(x => x.Get(id)).Returns(DTO);
            controller = new OwnerController(mockService.Object, mapper);

            admin_EditGetAction_ViewModelNotNull();
        }

        [TestMethod]
        public void EditPostAction_RedirectToIndexView()
        {
            // Arrange
            mockService.Setup(x => x.Update(DTO));
            controller = new OwnerController(mockService.Object, mapper);

            admin_EditPostAction_RedirectToIndexView();
        }

        [TestMethod]
        public void DeleteGetAction_ViewModelNotNull()
        {
            // Arrange
            mockService.Setup(x => x.Delete(id)).Returns(DTO);
            controller = new OwnerController(mockService.Object, mapper);

            admin_DeleteGetAction_ViewModelNotNull();
        }

        [TestMethod]
        public void DeletePostAction_RedirectToIndexView()
        {
            // Arrange
            mockService.Setup(x => x.Get(id)).Returns(DTO);
            controller = new OwnerController(mockService.Object, mapper);

            admin_DeletePostAction_RedirectToIndexView();
        }
    }
}