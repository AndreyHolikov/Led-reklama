using Microsoft.VisualStudio.TestTools.UnitTesting;
using Led.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Led.BLL.Interfaces;

namespace Led.BLL.Services.Tests
{
    [TestClass()]
    public class CityServiceTests
    {
        private CityService cityService;
        //private ViewResult result;

        [TestInitialize]
        public void SetupContext()
        {
            //cityService = new CityService();
            //result = controller.Index() as ViewResult;
        }

        public void CityService_Test()
        {
            // Act
            //ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.IsNotNull(result.Model);
        }
    }
}