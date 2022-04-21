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
        public void RegisterTest1()
        {
            string expected = new Response(true, "Registration successful!").GenerateJson();
            string result = service.Register("yuval@post.bgu.ac.il", "12345");
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void RegisterTest2()
        {
            string expected = new Response(false, "User already exists").GenerateJson();
            string result = service.Register("yuval@post.bgu.ac.il", "12345");
            result = service.Register("yuval@post.bgu.ac.il", "12345");
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void DeleteUserTest() 
        { 
            Assert.Fail();
        }

        [TestMethod()]
        public void LogInTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LogOutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetPasswordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetEmailTest()
        {
            Assert.Fail();
        }
    }
}