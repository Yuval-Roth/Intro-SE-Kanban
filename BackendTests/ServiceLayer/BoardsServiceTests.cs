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
        static BusinessLayer.UserData userData = new();
        UserService userservice = new UserService(userData);
        BusinessLayer.UserController userController = new BusinessLayer.UserController(userData);
        BoardsService boardservice = new BoardsService(userData);
        BusinessLayer.BoardController boardController = new BusinessLayer.BoardController(userData);
        string user = "kfirniss@post.bgu.ac.il";
        string duedate = "13/05/2022";
        string newboard = "new board";
        string anotherboard = "another board";
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

        //user has no boards to delete
        [TestMethod()]
        public void DeleteBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user has no boards to delete!"));
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
            result = boardservice.AddTask(user, newboard, duedate, "bla bla");
            result = boardservice.AddTask(user, anotherboard, duedate, "ni ni ni");
            result = boardservice.GetAllTasksByState(user, state.backlog.ToString().ToString());
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void GetAllTasksByStateTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't exist!"));
            string result = boardservice.GetAllTasksByState(user, state.backlog.ToString().ToString());
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
            result = boardservice.AddTask(user, newboard, duedate, "bla bla");
            result = boardservice.AddTask(user, anotherboard, duedate, "ni ni ni");
            result = userservice.LogOut(user);
            result = boardservice.GetAllTasksByState(user, state.backlog.ToString().ToString());
            Assert.AreEqual(expected, result);
        }

        //user has no boards
        [TestMethod()]
        public void GetAllTasksByStateTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user has no boards!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetAllTasksByState(user, state.backlog.ToString().ToString());
            Assert.AreEqual(expected, result);
        }

        //user has no task on this state
        [TestMethod()]
        public void GetAllTasksByStateTest4()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user has no task on this state!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = boardservice.AddTask(user, newboard, duedate, "bla bla");
            result = boardservice.AddTask(user, anotherboard, duedate, "ni ni ni");
            result = boardservice.GetAllTasksByState(user, state.inprogress.ToString().ToString());
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

        //user has no boards
        [TestMethod()]
        public void GetAllBoardsTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user has no boards!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetAllBoards(user);
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void SearchBoardTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "new board"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = boardservice.SearchBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //user doen't exist
        [TestMethod()]
        public void SearchBoardTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doen't exist!"));
            string result = boardservice.SearchBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void SearchBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user dosn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = userservice.LogOut(user);
            result = boardservice.SearchBoard(user, "new board");
            Assert.AreEqual(expected, result);
        }

        //board doesn't exist
        [TestMethod()]
        public void SearchBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "board doesn't exist!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.CreateBoard(user, "another board");
            result = boardservice.SearchBoard(user, "three board");
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void GetTaskTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "first task"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard, duedate, "bla bla");
            result = boardservice.GetTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void GetTaskTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't exist!"));
            string result = boardservice.GetTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void GetTaskTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard, duedate, "bla bla");
            result = userservice.LogOut(user);
            result = boardservice.GetTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
        }

        //user has no tasks
        [TestMethod()]
        public void GetTaskTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user has no tasks!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.GetTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
        }

        //task don't exist
        [TestMethod()]
        public void GetTaskTest4()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "task don't exist!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.GetTask(user, newboard, "other task");
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void GetAllTasksByTypeTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "need to implement"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.AddTask(user, newboard,  duedate, "ni ni ni");
            result = boardservice.GetAllTasksByType(user, newboard, state.backlog.ToString());
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void GetAllTasksByTypeTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't exist!"));
            string result = boardservice.GetAllTasksByType(user, newboard, state.backlog.ToString());
            Assert.AreEqual(expected, result);
        }

        //user doesn't login!
        [TestMethod()]
        public void GetAllTasksByTypeTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.AddTask(user, newboard,  duedate, "ni ni ni");
            result = userservice.LogOut(user);
            result = boardservice.GetAllTasksByType(user, newboard, state.backlog.ToString());
            Assert.AreEqual(expected, result);
        }

        //user has no boards
        [TestMethod()]
        public void GetAllTasksByTypeTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user has no boards!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.GetAllTasksByType(user, newboard, state.backlog.ToString());
            Assert.AreEqual(expected, result);
        }

        //user has no tasks on this type
        [TestMethod()]
        public void GetAllTasksByTypeTest4()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "user has no tasks on this type!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.AddTask(user, newboard,  duedate, "ni ni ni");
            result = boardservice.GetAllTasksByType(user, newboard, state.inprogress.ToString());
            Assert.AreEqual(expected, result);
        }


        //add task successful
        [TestMethod()]
        public void AddTaskTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "add task successful"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            Assert.AreEqual(expected, result);
        }

        //user doesn't exist
        [TestMethod()]
        public void AddTaskTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't exist!"));
            string result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void AddTaskTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user doesn't login!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = userservice.LogOut(user);
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            Assert.AreEqual(expected, result);
        }

        //user has no boards
        [TestMethod()]
        public void AddTaskTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user has no boards!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            Assert.AreEqual(expected, result);
        }

        //board doesn't exist
        [TestMethod()]
        public void AddTaskTest4()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "board doesn't exist!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, anotherboard, duedate, "bla bla");
            Assert.AreEqual(expected, result);
        }

        //task has already exist
        [TestMethod()]
        public void AddTaskTest5()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "task has already exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.AddTask(user, newboard, duedate, "ni ni ni");
            Assert.AreEqual(expected, result);
        }

        //delete task successful
        [TestMethod()]
        public void RemoveTaskTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "delete task successful"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.RemoveTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
        }

        //user has no tasks to delete
        [TestMethod()]
        public void RemoveTaskTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "user has no tasks to delete!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.RemoveTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
        }

        //task doesn't exist
        [TestMethod()]
        public void RemoveTaskTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "task doesn't exist!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.RemoveTask(user, newboard, "second task");
            Assert.AreEqual(expected, result);
        }

        //advance task successful
        [TestMethod()]
        public void AdvanceTaskTest()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "advance task successful"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.AdvanceTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
        }

        //advance task successful
        [TestMethod()]
        public void AdvanceTaskTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "advance task successful"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.AdvanceTask(user, newboard, "first task");
            result = boardservice.AdvanceTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
        }

        //task can't advance because its done
        [TestMethod()]
        public void AdvanceTaskTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "task can't advance because its done!"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardservice.CreateBoard(user, "new board");
            result = boardservice.AddTask(user, newboard,  duedate, "bla bla");
            result = boardservice.AdvanceTask(user, newboard, "first task");
            result = boardservice.AdvanceTask(user, newboard, "first task");
            result = boardservice.AdvanceTask(user, newboard, "first task");
            Assert.AreEqual(expected, result);
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