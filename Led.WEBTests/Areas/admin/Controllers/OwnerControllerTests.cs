using Microsoft.VisualStudio.TestTools.UnitTesting;
using Led.Areas.Admin.Controllers;
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

namespace Led.WEB.Areas.Admin.Controllers.Tests
{
    [TestClass()]
    public class OwnerControllerTests
    {
        [TestMethod()]
        public void Index_Test()
        {
            Assert.Fail();
        }
    }
}

namespace Led.Areas.Admin.Controllers.Tests
{
    [TestClass()]
    public class OwnerControllerTests
    {

        [TestMethod()]
        public void OwnerController_Index_IsNotNull()
        {
            //// Arrange
            //IUnitOfWork unitOfWork = new EFUnitOfWork(@"Data Source=PC-631\SQLEXPRESS;Initial Catalog=LedCatalog_18042018_DB;Integrated Security=True");
            ////OwnerController controller = new OwnerController(unitOfWork);// mock.Object);
            //var controller = new OwnerController(new OwnerService(unitOfWork));

            //// Act
            //ViewResult result = controller.Index() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result.Model);
        }

        //[TestMethod()]
        //public void DetailsTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void CreateTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void CreateTest1()
        //{
        //    Assert.Fail();
        //}
    }
}