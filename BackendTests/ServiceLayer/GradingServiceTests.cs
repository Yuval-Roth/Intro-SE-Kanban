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
    public class GradingServiceTests
    {
        UserService service = new UserService();

        [TestMethod()]
        //Registration success
        public void RegisterTest()
        {
            string expected = JsonController.ConvertToJson(new Response("{}"));
            string result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //user exist in the system
        [TestMethod()]
        public void RegisterTest1()
        {
            string expected = JsonController.ConvertToJson(new Response("Element already exists in the tree"));
            string result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //invalid password
        [TestMethod()]
        public void RegisterTest2()
        {
            string expected = JsonController.ConvertToJson(new Response("Password illegal"));
            string result = service.Register("yuval@post.bgu.ac.il", "a12345");
            Assert.AreEqual(expected, result);
        }
        //null email
        [TestMethod()]
        public void RegisterTest3()
        {
            string expected = JsonController.ConvertToJson(new Response("Email is null"));
            string result = service.Register(null, "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //null password
        [TestMethod()]
        public void RegisterTest4()
        {
            string expected = JsonController.ConvertToJson(new Response("Password is null"));
            string result = service.Register("yuval@post.bgu.ac.il", null);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        //LogIn success
        public void LogInTest()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("{}"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //incorrect password
        [TestMethod()]
        public void LogInTest1()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("Incorrect Password"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas6789");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void LogInTest2()
        {
            string expected = JsonController.ConvertToJson(new Response("There is no such user in the system"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //user allready loggedIn
        [TestMethod()]
        public void LogInTest3()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.LogIn("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("User is already logged in"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null email
        [TestMethod()]
        public void LogInTest4()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("Email is null"));
            string result = service.LogIn(null, "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null password
        [TestMethod()]
        public void LogInTest5()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("Password is null"));
            string result = service.LogIn("printz@post.bgu.il", null);
            Assert.AreEqual(expected, result);
        }

 
        //logOut successesful
        [TestMethod()]
        public void LogOutTest()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.LogIn("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("{}"));
            string result = service.LogOut("printz@post.bgu.il");
            Assert.AreEqual(expected, result);

        }
        //user isn't loggedIn
        [TestMethod()]
        public void LogOutTest1()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("User isn't loggedIn"));
            string result = service.LogOut("printz@post.bgu.il");
            Assert.AreEqual(expected, result);

        }
        //null user
        [TestMethod()]
        public void LogOutTest2()
        {
            string expected = JsonController.ConvertToJson(new Response("User is null"));
            string result = service.LogOut(null);
            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void LimitColumnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetColumnLimitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetColumnNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTaskTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTaskDueDateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTaskTitleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTaskDescriptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AdvanceTaskTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetColumnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBoardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveBoardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InProgressTasksTest()
        {
            Assert.Fail();
        }
    }
}