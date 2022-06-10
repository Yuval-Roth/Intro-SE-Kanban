using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroSE.Kanban.Backend.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.Tests
{
    [TestClass()]
    public class UserControllerDTOTests
    {
        UserControllerDTO userControllerDTO;
        UserService service;

        public UserControllerDTOTests()
        {
            ServiceLayerFactory.DeleteEverything();
            ServiceLayerFactory ServiceFactory = ServiceLayerFactory.GetInstance();
            DataAccessLayerFactory DataFactory = DataAccessLayerFactory.GetInstance();
            userControllerDTO = DataFactory.UserControllerDTO;
            service = ServiceFactory.UserService;
        }


        [TestMethod()]
        public void AddUserTest()
        {
            service.Register("printz@post.bgu.ac.il", "Hadas1234");

            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ChangePasswordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ChangeEmailTest()
        {
            Assert.Fail();
        }
    }
}