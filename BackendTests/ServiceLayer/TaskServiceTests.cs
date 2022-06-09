using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroSE.Kanban.Backend.BusinessLayer;
using System;


namespace IntroSE.Kanban.Backend.ServiceLayer.Tests
{
    [TestClass()]
    public class TaskServiceTests
    {

        UserService userservice;
        BoardControllerService boardcontrollerservice;
        BoardService boardservice;
        TaskService taskservice;

        public TaskServiceTests()
        {
            BusinessLayerFactory.DeleteEverything();
            BusinessLayerFactory factory = BusinessLayerFactory.GetInstance();
            userservice = new UserService(factory.UserController);
            boardcontrollerservice = new BoardControllerService(factory.BoardController);
            boardservice = new BoardService(factory.BoardController);
            taskservice = new TaskService(factory.BoardController);
        }

        //successful
        [TestMethod()]
        public void UpdateTaskDueDateSuccess()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 0, new DateTime(2022, 05, 20));
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void UpdateTaskDueDateUserIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime(2022, 05, 20));
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void UpdateTaskDueDateUserIsntLog()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user 'kfirniss@post.bgu.ac.il' isn't logged in"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogOut("kfirniss@post.bgu.ac.il");
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime(2022, 05, 20));
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void UpdateTaskDueDateBoardIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled 'new board' doesn't exists for the user with the email kfirniss@post.bgu.ac.il"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime(2022, 05, 20));
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void UpdateTaskDueDateColumnIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "The column '5' is not a valid column number"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 5, 1, new DateTime(2022, 05, 20));
            Assert.AreEqual(expected, result);
        }

        //task isn't exist
        [TestMethod()]
        public void UpdateTaskDueDateTaskIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A Task with the taskId '5' doesn't exist in column '0'"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 5, new DateTime(2022, 05, 20));
            Assert.AreEqual(expected, result);
        }

        //user isnt the assignee
        //[TestMethod()]
        //public void UpdateTaskDueDateNotAssignee()
        //{
        //    string expected = JsonController.ConvertToJson(new Response<string>(false, "This is not the assignee"));
        //    string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
        //    result = userservice.LogIn("kfirniss@post.bgu.ac.il", "Ha12345");
        //    result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
        //    result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20), "printz@post.bgu.ac.il");
        //    result = taskservice.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 0, new DateTime(2022, 05, 20));
        //    Assert.AreEqual(expected, result);
        //}

        //successful
        [TestMethod()]
        public void UpdateTaskTitleTestSuccess()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 0, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void UpdateTaskTitleUserIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void UpdateTaskTitleUserIsntLog()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user 'kfirniss@post.bgu.ac.il' isn't logged in"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogOut("kfirniss@post.bgu.ac.il");
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void UpdateTaskTitleBoardIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled 'new board' doesn't exists for the user with the email kfirniss@post.bgu.ac.il"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void UpdateTaskTitleColumnIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "The column '5' is not a valid column number"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 5, 0, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //task isn't exist
        [TestMethod()]
        public void UpdateTaskTitleTaskIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A Task with the taskId '1' doesn't exist in column '0'"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
            Assert.AreEqual(expected, result);
        }

        //invalid title length- empty title
        [TestMethod()]
        public void UpdateTaskTitleEmptyNewTitle()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "The title is empty"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "");
            Assert.AreEqual(expected, result);
        }

        //invalid title length- more than 50
        [TestMethod()]
        public void UpdateTaskTitleTitleTooLong()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "Title's length is over 50"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            string title = "";
            for(int i = 0; i < 60; i++)
            {
                title = title + 'a';
            }
            result = taskservice.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, title);
            Assert.AreEqual(expected, result);
        }

        //successful
        [TestMethod()]
        public void UpdateTaskDescriptionSuccess()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 0, "new task description");
            Assert.AreEqual(expected, result);
        }

        //user isn't exist
        [TestMethod()]
        public void UpdateTaskDescriptionUserIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user with the email 'kfirniss@post.bgu.ac.il' doesn't exist in the system"));
            string result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 0, "new task description");
            Assert.AreEqual(expected, result);
        }

        //user doesn't login
        [TestMethod()]
        public void UpdateTaskDescriptionUserIsntLog()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "user 'kfirniss@post.bgu.ac.il' isn't logged in"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = userservice.LogOut("kfirniss@post.bgu.ac.il");
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 0, "new task description");
            Assert.AreEqual(expected, result);
        }

        //board isn't exist
        [TestMethod()]
        public void UpdateTaskDescriptionBoardIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A board titled 'new board' doesn't exists for the user with the email kfirniss@post.bgu.ac.il"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 0, "new task description");
            Assert.AreEqual(expected, result);
        }

        //column isn't exist
        [TestMethod()]
        public void UpdateTaskDescriptionColumnIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "The column '3' is not a valid column number"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 3, 0, "new task description");
            Assert.AreEqual(expected, result);
        }

        //task isn't exist
        [TestMethod()]
        public void UpdateTaskDescriptionTaskIsntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A Task with the taskId '0' doesn't exist in column '0'"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 0, "new task description");
            Assert.AreEqual(expected, result);
        }

        //description too long
        [TestMethod()]
        public void UpdateTaskDescriptionTooLong()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "Description length is over 300"));
            string result = userservice.Register("kfirniss@post.bgu.ac.il", "Ha12345");
            result = boardcontrollerservice.AddBoard("kfirniss@post.bgu.ac.il", "new board");
            result = boardservice.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime(2022, 05, 20));
            string description = "";
            for(int i= 0; i < 310; i++)
            {
                description = description + 'a';
            }
            result = taskservice.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 0, description);
            Assert.AreEqual(expected, result);
        }
    }
}