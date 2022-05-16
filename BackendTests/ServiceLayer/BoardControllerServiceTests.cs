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
        BusinessLayer.UserData userData;
        UserService userservice;
        BoardControllerService boardcontrollerservice;
        BoardService boardservice;
        TaskService taskservice;

        public BoardControllerServiceTests()
        {
            userData = new();
            userservice = new(userData);
            boardcontrollerservice = new(userData);
            boardservice = new(userData);
            taskservice = new(userData);
        }

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
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void AddBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't login to the system"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result =boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //board already existed
        [TestMethod()]
        public void AddBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled new board already exists for the user with the email kfirniss@post.bgu.ac.il"));
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
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void RemoveBoardTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't login to the system"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //user has no boards to delete
        [TestMethod()]
        public void RemoveBoardTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled 'new board' doesn't exists for the user with the email kfirniss@post.bgu.ac.il"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        //board doesn't exist
        [TestMethod()]
        public void RemoveBoardTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled 'other board' doesn't exists for the user with the email kfirniss@post.bgu.ac.il"));
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
            LinkedList<BusinessLayer.Task> board = new();
            board.AddLast(new BusinessLayer.Task(0, "task 1", new DateTime(), "bla bla bla"));
            board.AddLast(new BusinessLayer.Task(0, "task 2", new DateTime(), "ninini"));
            board.ElementAt(0).AdvanceTask();
            board.ElementAt(1).AdvanceTask();
            string expected = JsonController.ConvertToJson(new Response<object>(true, board));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "another board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime());
            result = boardservice.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 0);
            result = boardservice.AdvanceTask("kfirniss@post.bgu.ac.il", "another board", 0, 0);
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il",1);
            Assert.AreEqual(expected, result);
        }

        //user dosen't exist
        [TestMethod()]
        public void GetAllTasksByStateTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void GetAllTasksByStateTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't login to the system"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        //user has no boards
        [TestMethod()]
        public void GetAllTasksByStateTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<LinkedList<BusinessLayer.Task>> (true,new LinkedList<BusinessLayer.Task>()));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        //user has no task on this state
        [TestMethod()]
        public void GetAllTasksByStateTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<LinkedList<BusinessLayer.Task>>(true, new LinkedList<BusinessLayer.Task>()));
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