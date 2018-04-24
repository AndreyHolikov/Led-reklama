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
    public abstract class BaseControllerTests
    {
        protected Mock<IOwnerService> mockService;
        protected IMapper mapper;
        protected OwnerController controller;
        protected int id = 1;
        protected string expected = "Index";
        protected OwnerViewModel viewModel;
        protected OwnerDTO DTO;

        protected void admin_Index_ModelNotNull()
        {
            // Act / action
            var result = controller.Index() as ViewResult;

            // Assert 
            Assert.IsNotNull(result.Model);
        }

        protected void admin_Details_ModelNotNull()
        {
            // Act / action
            var result = controller.Details(id) as ViewResult;

            // Assert 
            Assert.IsNotNull(result.Model);
        }

        protected void admin_CreatePostAction_ModelError()
        {
            // act
            ViewResult result = controller.Create(viewModel) as ViewResult;
            
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }

        protected void admin_CreatePostAction_RedirectToIndexView()
        {
            // Act
            RedirectToRouteResult result = controller.Create(viewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        protected void admin_EditGetAction_ViewModelNotNull()
        {
            // Act / action
            var result = controller.Edit(id) as ViewResult;

            // Assert 
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        protected void admin_EditPostAction_RedirectToIndexView()
        {
            // Act
            RedirectToRouteResult result = controller.Edit(viewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        protected void admin_DeleteGetAction_ViewModelNotNull()
        {
            // Act / action
            var result = controller.Delete(id) as ViewResult;

            // Assert 
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        protected void admin_DeletePostAction_RedirectToIndexView()
        {
            // Act / action
            RedirectToRouteResult result = controller.DeleteConfirmed(id) as RedirectToRouteResult;

            // Assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["Action"]);
        }
    }
}