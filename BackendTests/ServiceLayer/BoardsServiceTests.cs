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
    public class BoardsServiceTests
    {
        UserService userservice = new UserService();
        BusinessLayer.UserController userController = new BusinessLayer.UserController();
        BoardsService boardservice = new BoardsService();
        BusinessLayer.BoardController boardController = new BusinessLayer.BoardController();

        //create successful
        [TestMethod()]
        public void CreateBoardTest()
        {
            BusinessLayer.User user = new("kfirniss@post.bgu.ac.il", "Ha12345");
            string expected = JsonController.ConvertToJson(new Response(true, "creation successful!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void CreateBoardTest1()
        {
            BusinessLayer.User user = new("kfirniss@post.bgu.ac.il", "Ha12345");
            string expected = JsonController.ConvertToJson(new Response(true, "user doesn't exist!"));
            string result = boardservice.CreateBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void CreateBoardTest2()
        {
            BusinessLayer.User user = new("kfirniss@post.bgu.ac.il", "Ha12345");
            string expected = JsonController.ConvertToJson(new Response(true, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //board already existed
        [TestMethod()]
        public void CreateBoardTest3()
        {
            BusinessLayer.User user = new("kfirniss@post.bgu.ac.il", "Ha12345");
            string expected = JsonController.ConvertToJson(new Response(true, "board already existed!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DeleteBoardTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllTasksByStateTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllBoardsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SearchBoardTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetTaskTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllTasksByTypeTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddTaskTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void RemoveTaskTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AdvanceTaskTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SetTaskTitleTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetTaskDuedateTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SetTaskDuedateTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetTaskDescriptionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SetTaskDescriptionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetTaskStateTest()
        {
            throw new NotImplementedException();
        }
    }
}