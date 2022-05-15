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
    public class BoardControllerServiceTests
    {
        static BusinessLayer.UserData userData= new();
        UserService userservice = new(userData);
        BoardControllerService boardcontrollerservice = new(userData);
        BoardService boardservice = new(userData);
        TaskService taskservice = new(userData);

        //create successful
        [TestMethod()]
        public void AddBoardTest()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void AddBoardTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"true,user doesn't exist!"));
            string result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void AddBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result =boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //board already existed
        [TestMethod()]
        public void AddBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board already existed!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //Delete successful
        [TestMethod()]
        public void RemoveBoardTest()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist 
        [TestMethod()]
        public void RemoveBoardTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user doesn't exist!"));
            string result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void RemoveBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user has no boards to delete
        [TestMethod()]
        public void RemoveBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user has no boards to delete!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //board doesn't exist
        [TestMethod()]
        public void RemoveBoardTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"true,board doesn't exist!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "other board");
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void GetAllTasksByStateTest()
        {
            string expected = JsonController.ConvertToJson(new Response<object>(true,new object()));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "another board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime());
            result = taskservice.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
            result = taskservice.AdvanceTask("kfirniss@post.bgu.ac.il", "another board", 0, 1);
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il",1);
            Assert.AreEqual(expected, result);
        }

        //user dosen't exist
        [TestMethod()]
        public void GetAllTasksByStateTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't exist!"));
            string result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void GetAllTasksByStateTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        //user has no boards
        [TestMethod()]
        public void GetAllTasksByStateTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user has no boards"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        //user has no task on this state
        [TestMethod()]
        public void GetAllTasksByStateTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user has no task on this state"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "another board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime());
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }
    }
}