using Microsoft.VisualStudio.TestTools.UnitTesting;
using Led.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Led.DAL.Interfaces;
using Led.DAL.Repositories;
using Led.BLL.DTO;
using Led.DAL.Entities;

namespace Led.BLL.Services.Tests
{
    [TestClass()]
    public class AddressServiceTests
    {
        [TestMethod]
        public void Led_BLL_Services_AddressService_GetAll_Test()
        {
            // Arrange
            IUnitOfWork unitOfWork = new EFUnitOfWork(@"Data Source=PC-631\SQLEXPRESS;Initial Catalog=LedCatalog_18042018_DB;Integrated Security=True");
            AddressService addressService = new AddressService(unitOfWork);

            // Act
            ICollection<AddressDTO> addresses = addressService.GetAll().ToList();

            // Assert
            Assert.IsNotNull(addresses);
            Assert.IsTrue(addresses.Count > 0);
        }
    }
}