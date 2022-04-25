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
        GradingService service = new GradingService();

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
            string result = service.Login("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //incorrect password
        [TestMethod()]
        public void LogInTest1()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("Incorrect Password"));
            string result = service.Login("printz@post.bgu.il", "Hadas6789");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void LogInTest2()
        {
            string expected = JsonController.ConvertToJson(new Response("There is no such user in the system"));
            string result = service.Login("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //user allready loggedIn
        [TestMethod()]
        public void LogInTest3()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.Login("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("User is already logged in"));
            string result = service.Login("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null email
        [TestMethod()]
        public void LogInTest4()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("Email is null"));
            string result = service.Login(null, "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null password
        [TestMethod()]
        public void LogInTest5()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("Password is null"));
            string result = service.Login("printz@post.bgu.il", null);
            Assert.AreEqual(expected, result);
        }

 
        //logOut successesful
        [TestMethod()]
        public void LogOutTest()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.Login("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("{}"));
            string result = service.Logout("printz@post.bgu.il");
            Assert.AreEqual(expected, result);

        }
        //user isn't loggedIn
        [TestMethod()]
        public void LogOutTest1()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response("User isn't loggedIn"));
            string result = service.Logout("printz@post.bgu.il");
            Assert.AreEqual(expected, result);

        }
        //null user
        [TestMethod()]
        public void LogOutTest2()
        {
            string expected = JsonController.ConvertToJson(new Response("User is null"));
            string result = service.Logout(null);
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

        //create successful
        [TestMethod()]
        public void AddBoardTest()
        {
            string expected = JsonController.ConvertToJson(new Response("{}"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void AddBoardTest1()
        {
            string expected = JsonController.ConvertToJson(new Response("user doesn't exist!"));
            string result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void AddBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't login!"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //board already existed
        [TestMethod()]
        public void AddBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response("board already existed!"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //Delete successful
        [TestMethod()]
        public void RemoveBoardTest()
        {
            string expected = JsonController.ConvertToJson(new Response("{}"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist 
        [TestMethod()]
        public void RemoveBoardTest1()
        {
            string expected = JsonController.ConvertToJson(new Response("user doesn't exist!"));
            string result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void RemoveBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response("user doesn't login!"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user has no boards to delete
        [TestMethod()]
        public void RemoveBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response("user has no boards to delete!"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //board doesn't exist
        [TestMethod()]
        public void RemoveBoardTest4()
        {
            string expected = JsonController.ConvertToJson(new Response("board doesn't exist!"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "other board");
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void InProgressTasksTest()
        {
            string expected = JsonController.ConvertToJson(new Response(new Object()));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "another board");
            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = service.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime());
            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "another board", 0, 1);
            result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
            Assert.AreEqual(expected, result);
        }

        //user dosen't exist
        [TestMethod()]
        public void InProgressTasksTest1()
        {
            string expected = JsonController.ConvertToJson(new Response("user doesn't exist!"));
            string result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void InProgressTasksTest2()
        {
            string expected = JsonController.ConvertToJson(new Response("user doesn't login"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
            Assert.AreEqual(expected, result);
        }

        //user has no boards
        [TestMethod()]
        public void InProgressTasksTest3()
        {
            string expected = JsonController.ConvertToJson(new Response("user has no boards"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
            Assert.AreEqual(expected, result);
        }

        //user has no inprogress tasks
        [TestMethod()]
        public void InProgressTasksTest4()
        {
            string expected = JsonController.ConvertToJson(new Response("user has no inprogress tasks"));
            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = service.AddBoard("kfirniss@post.bgu.ac.il", "another board");
            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = service.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime());
            result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
            Assert.AreEqual(expected, result);
        }

    }
}