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
        UserService userservice;
        BoardControllerService boardcontrollerservice;
        BoardService boardservice;
        TaskService taskservice;

        public BoardControllerServiceTests()
        {
            BusinessLayer.BusinessLayerFactory.DeleteEverything();
            BusinessLayer.BusinessLayerFactory factory = BusinessLayer.BusinessLayerFactory.GetInstance();
            userservice = new UserService(factory.UserController);
            boardcontrollerservice = new BoardControllerService(factory.BoardController);
            boardservice = new BoardService(factory.BoardController);
            taskservice = new TaskService(factory.BoardController);
        }

        [TestMethod()]
        public void AddBoardTest_sucessful()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddBoardTest_user_doesnt_exist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddBoardTest_user_not_logged_in()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user 'kfirniss@post.bgu.ac.il' isn't logged in"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogOut("kfirniss@post.bgu.ac.il");
            result =boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddBoardTest_board_already_exists()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled new board already exists for the user with the email kfirniss@post.bgu.ac.il"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RemoveBoardTest_successful()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RemoveBoardTest1_user_doesnt_exist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RemoveBoardTest_user_not_logged_in()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user 'kfirniss@post.bgu.ac.il' isn't logged in"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogOut("kfirniss@post.bgu.ac.il");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RemoveBoardTest_user_has_no_boards_to_delete()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled 'new board' doesn't exists for the user with the email kfirniss@post.bgu.ac.il"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RemoveBoardTest_board_doesnt_exist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled 'other board' doesn't exists for the user with the email kfirniss@post.bgu.ac.il"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.RemoveBoard("kfirniss@post.bgu.ac.il", "other board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RemoveBoardTest_user_isnt_owner()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled 'new board' can't be removed by the user with the email Printzpost.bgu.ac.il"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = userservice.Register("Printzpost.bgu.ac.il", "Ha12345");
            result = boardservice.JoinBoard("Printzpost.bgu.ac.il", 0);
            result = boardcontrollerservice.RemoveBoard("Printzpost.bgu.ac.il", "new Board");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetAllTasksByStateTest_successful()
        {
            BusinessLayer.Task task1 = new(0, "task 1", new DateTime(2022, 05, 20), "bla bla bla");
            BusinessLayer.Task task2 = new(1, "task 2", new DateTime(2022, 05, 20), "ninini");
            userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "another board");
            boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            boardservice.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime(2022, 05, 20));
            boardservice.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 0);
            boardservice.AdvanceTask("kfirniss@post.bgu.ac.il", "another board", 0, 1);
            string result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il",1);
            Response<LinkedList<BusinessLayer.Task>> act = JsonController.BuildFromJson<Response<LinkedList<BusinessLayer.Task>>>(result);
            BusinessLayer.Task tAct1 = act.returnValue.ElementAt(0);
            BusinessLayer.Task tAct2 = act.returnValue.ElementAt(1);
            Assert.IsFalse(task1.Id != tAct1.Id || task1.Title != tAct1.Title || task1.Description != tAct1.Description || task1.DueDate != tAct1.DueDate);
            Assert.IsFalse(task2.Id != tAct2.Id || task2.Title != tAct2.Title || task2.Description != tAct2.Description || task2.DueDate != tAct2.DueDate);
        }

        [TestMethod()]
        public void GetAllTasksByStateTest_user_doesnt_exist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetAllTasksByStateTest_user_not_logged_in()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user 'kfirniss@post.bgu.ac.il' isn't logged in"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogOut("kfirniss@post.bgu.ac.il");
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetAllTasksByStateTest_user_has_no_boards()
        {
            string expected = JsonController.ConvertToJson(new Response<LinkedList<BusinessLayer.Task>> (true,new LinkedList<BusinessLayer.Task>()));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetAllTasksByStateTest_user_has_no_task_in_the_state()
        {
            string expected = JsonController.ConvertToJson(new Response<LinkedList<BusinessLayer.Task>>(true, new LinkedList<BusinessLayer.Task>()));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "another board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022,05,20));
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime(2022, 05, 20));
            result = boardcontrollerservice.GetAllTasksByState("kfirniss@post.bgu.ac.il", 1);
            Assert.AreEqual(expected, result);
        }
    }
}