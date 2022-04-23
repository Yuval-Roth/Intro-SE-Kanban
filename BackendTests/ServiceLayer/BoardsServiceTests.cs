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
        BusinessLayer.User user = new("kfirniss@post.bgu.ac.il", "Ha12345");
        BusinessLayer.Date duedate = new("13/05/2022");
        BusinessLayer.Board newboard = new("new board");
        BusinessLayer.Board anotherboard = new("another board");
        public enum state
        {
            backlog,
            inprogress,
            done
        }

        //create successful
        [TestMethod()]
        public void CreateBoardTest()
        {
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
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't exist!"));
            string result = boardservice.CreateBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void CreateBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //board already existed
        [TestMethod()]
        public void CreateBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "board already existed!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //Delete successful
        [TestMethod()]
        public void DeleteBoardTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "Delete successful!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.DeleteBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist 
        [TestMethod()]
        public void DeleteBoardTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't exist!"));
            string result = boardservice.DeleteBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void DeleteBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = userservice.LogOut(user);
            result = boardservice.DeleteBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //user have no boards to delete
        [TestMethod()]
        public void DeleteBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user have no boards to delete!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.DeleteBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //board doesn't exist
        [TestMethod()]
        public void DeleteBoardTest4()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "board doesn't exist!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.DeleteBoard(user, "another board");
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void GetAllTasksByStateTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "need to implement"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = boardservice.AddTask(user, newboard, "first task", duedate, "bla bla");
            result = boardservice.AddTask(user, anotherboard, "second task", duedate, "ni ni ni");
            result = boardservice.GetAllTasksByState(user, state.backlog);
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void GetAllTasksByStateTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't exist!"));
            string result = boardservice.GetAllTasksByState(user, state.backlog);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void GetAllTasksByStateTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = boardservice.AddTask(user, newboard, "first task", duedate, "bla bla");
            result = boardservice.AddTask(user, anotherboard, "second task", duedate, "ni ni ni");
            result = userservice.LogOut(user);
            result = boardservice.GetAllTasksByState(user, state.backlog);
            Assert.AreEqual(expected, result);
        }

        //user have no boards
        [TestMethod()]
        public void GetAllTasksByStateTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user have no boards!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetAllTasksByState(user, state.backlog);
            Assert.AreEqual(expected, result);
        }

        //user have no task on this state
        [TestMethod()]
        public void GetAllTasksByStateTest4()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user have no task on this state!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = boardservice.AddTask(user, newboard, "first task", duedate, "bla bla");
            result = boardservice.AddTask(user, anotherboard, "second task", duedate, "ni ni ni");
            result = boardservice.GetAllTasksByState(user, state.inprogress);
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void GetAllBoardsTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "need to implement"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = boardservice.GetAllBoards(user);
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void GetAllBoardsTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't exist!"));
            string result = boardservice.GetAllBoards(user);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void GetAllBoardsTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = userservice.LogOut(user);
            result = boardservice.GetAllBoards(user);
            Assert.AreEqual(expected, result);
        }

        //user have no boards
        [TestMethod()]
        public void GetAllBoardsTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user have no boards!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetAllBoards(user);
            Assert.AreEqual(expected, result);
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