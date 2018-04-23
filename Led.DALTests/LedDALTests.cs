using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Led.DAL.Repositories;
using Led.DAL.Interfaces;
using Led.WEB.Util;
using System.Collections;
using System.Collections.Generic;
using Led.DAL.Entities;
using System.Linq;
using System.Data.Entity;
using Led.BLL.Services;
using Led.BLL.DTO;

namespace Led.Tests.Led.DAL.Tests
{
    [TestClass]
    public class LedDALTests
    {
        [TestMethod]
        public void LedDal_UnitOfWork_AddressGetAll_NotNull()
        {
            // Arrange
            IUnitOfWork unitOfWork = new EFUnitOfWork(@"Data Source=PC-631\SQLEXPRESS;Initial Catalog=LedCatalog_18042018_DB;Integrated Security=True");

            // Act
            ICollection<Address> addresses = unitOfWork.Addresses.GetAll().ToList();

            // Assert
            Assert.IsTrue(addresses.Count > 0);
        }
    }
}
