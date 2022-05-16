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
    public class TaskServiceTests
    {

        static BusinessLayer.UserData userData = new();
        UserService userservice = new(userData);
        BoardControllerService boardcontrollerservice = new(userData);
        BoardService boardservice = new(userData);
        TaskService taskservice = new(userData);

        //successful
        [TestMethod()]
        public void UpdateTaskDueDateTest()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime());
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void UpdateTaskDueDateTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
            string result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime());
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void UpdateTaskDueDateTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime());
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void UpdateTaskDueDateTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime());
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void UpdateTaskDueDateTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 5, 1, new DateTime());
            Assert.AreEqual(expected, result);
        }

        //task isn't exist
        [TestMethod()]
        public void UpdateTaskDueDateTest5()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"task isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 5, new DateTime());
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void UpdateTaskTitleTest()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void UpdateTaskTitleTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
            string result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void UpdateTaskTitleTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void UpdateTaskTitleTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void UpdateTaskTitleTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //task isn't exist
        [TestMethod()]
        public void UpdateTaskTitleTest5()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"task isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void UpdateTaskDescriptionTest()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void UpdateTaskDescriptionTest1()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
            string result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void UpdateTaskDescriptionTest2()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void UpdateTaskDescriptionTest3()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void UpdateTaskDescriptionTest4()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
            Assert.AreEqual(expected, result);
        }

        //task isn't exist
        [TestMethod()]
        public void UpdateTaskDescriptionTest5()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"task isn't exist"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
            Assert.AreEqual(expected, result);
        }
    }
}