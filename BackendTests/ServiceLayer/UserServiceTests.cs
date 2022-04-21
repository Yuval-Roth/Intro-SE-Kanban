using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroSE.Kanban.Backend.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        UserService service = new UserService();

        [TestMethod()]
        public void UserServiceTest()
        {
            Assert.AreEqual();
                
        }

        [TestMethod()]
        public void registerTest1()
        {
            string expected = new Response(true, "Registration successful!").GenerateJson();
            string result = service.register("yuval@post.bgu.ac.il", "12345");
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void registerTest2()
        {
            string expected = new Response(false, "User already exists").GenerateJson();
            string result = service.register("yuval@post.bgu.ac.il", "12345");
            result = service.register("yuval@post.bgu.ac.il", "12345");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void deleteUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void logInTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void logOutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void setPasswordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void setEmailTest()
        {
            Assert.Fail();
        }
    }
}