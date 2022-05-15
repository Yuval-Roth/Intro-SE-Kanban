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
    public class BoardServiceTests
    {
        static BusinessLayer.UserData userData = new();
        UserService userservice = new(userData);
        BoardControllerService boardcontrollerservice = new(userData);
        BoardService boardservice = new(userData);

        //successful
        [TestMethod()]
        public void AddTaskTest()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void AddTaskTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't exist"));
            string result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void AddTaskTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void AddTaskTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            Assert.AreEqual(expected, result);
        }

        //column can't over the limit
        [TestMethod()]
        public void AddTaskTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column can't over the limit"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "ni ni ni", new DateTime());
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void RemoveTaskTest()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.RemoveTask("kfirniss@post.bgu.ac.il", "new board", 1);
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void RemoveTaskTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't exist"));
            string result = boardservice.RemoveTask("kfirniss@post.bgu.ac.il", "new board", 1);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void RemoveTaskTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.RemoveTask("kfirniss@post.bgu.ac.il", "new board", 1);
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void RemoveTaskTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.RemoveTask("kfirniss@post.bgu.ac.il", "new board", 1);
            Assert.AreEqual(expected, result);
        }

        //task isn't exist
        [TestMethod()]
        public void RemoveTaskTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.RemoveTask("kfirniss@post.bgu.ac.il", "new board", 1);
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void LimitColumnTest()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void LimitColumnTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
            string result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void LimitColumnTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            Assert.AreEqual(expected, result);
        }

        //borard isn't exist
        [TestMethod()]
        public void LimitColumnTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void LimitColumnTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 5, 1);
            Assert.AreEqual(expected, result);
        }

        //column has more tasks than the limit
        [TestMethod()]
        public void LimitColumnTest5()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column has more tasks than the limit"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 2", "ni ni ni", new DateTime());
            result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void GetColumnLimitTest()
        {
            string expected = JsonController.ConvertToJson(new Response<object>(true,new object()));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            result = boardservice.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void GetColumnLimitTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
            string result = boardservice.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void GetColumnLimitTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void GetColumnLimitTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void GetColumnLimitTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            result = boardservice.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 7);
            Assert.AreEqual(expected, result);
        }

        //column is unlimited
        [TestMethod()]
        public void GetColumnLimitTest5()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column is unlimited"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void GetColumnNameTest()
        {
            string expected = JsonController.ConvertToJson(new Response<object>(false,new object()));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void GetColumnNameTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
            string result = boardservice.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void GetColumNameTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void GetColumnNameTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void GetColumnNameTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 7);
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void GetColumnTest()
        {
            string expected = JsonController.ConvertToJson(new Response<object>(true,new object()));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.GetColumn("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void GetColumnTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
            string result = boardservice.GetColumn("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void GetColumnTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetColumn("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void GetColumnTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetColumn("kfirniss@post.bgu.ac.il", "new board", 0);
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void GetColumnTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.GetColumn("kfirniss@post.bgu.ac.il", "new board", 5);
            Assert.AreEqual(expected, result);
        }

        //column is empty
        [TestMethod()]
        public void GetColumnTest5()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column is empty"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.GetColumn("kfirniss@post.bgu.ac.il", "new board", 1);
            Assert.AreEqual(expected, result);
        }
    }
}