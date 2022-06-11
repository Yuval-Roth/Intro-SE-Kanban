using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroSE.Kanban.Backend.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.Tests
{
    [TestClass()]
    public class TaskControllerDTOTests
    {
        UserService userService;
        BoardControllerService boardControllerService;
        BoardService boardService;
        TaskService taskService;
        SQLExecuter executer;

        public TaskControllerDTOTests()
        {
            Backend.BusinessLayer.BusinessLayerFactory.GetInstance().DataCenterManagement.DeleteData();
            ServiceLayerFactory.DeleteEverything();
            ServiceLayerFactory ServiceFactory = ServiceLayerFactory.GetInstance();
            DataAccessLayerFactory DataFactory = DataAccessLayerFactory.GetInstance();
            userService = ServiceFactory.UserService;
            boardService = ServiceFactory.BoardService;
            taskService = ServiceFactory.TaskService;
            executer = DataFactory.SQLExecuter;
        }


        [TestMethod()]
        public void AddTaskTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            string taskTitle = "task1";
            string description = "desc1";
            DateTime dueDate = new DateTime(20 / 05 / 2023);
            if (GetOperationState(userService.Register(email, password))==false)
                Assert.Fail("Register failed");
            if (GetOperationState(boardControllerService.AddBoard(email, boardName))==false)
                Assert.Fail("AddBoard failed");
            string result = boardService.AddTask(email, boardName, taskTitle, description, dueDate);
            string query = "SELECT * FROM Tasks WHERE TaskId=0";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void RemoveTaskTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            string taskTitle = "task1";
            string description = "desc1";
            DateTime dueDate = new DateTime(20 / 05 / 2023);
            if (GetOperationState(userService.Register(email, password)) == false)
                Assert.Fail("Register failed");
            if (GetOperationState(boardControllerService.AddBoard(email, boardName)) == false)
                Assert.Fail("AddBoard failed");
            if (GetOperationState(boardService.AddTask(email, boardName, taskTitle, description, dueDate))==false)
                Assert.Fail("AddTask failed"); ;
            string result = boardService.RemoveTask(email, boardName, 0);
            string query = "SELECT * FROM Tasks WHERE TaskId=0";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void ChangeTaskStateTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            string taskTitle = "task1";
            string description = "desc1";
            DateTime dueDate = new DateTime(20 / 05 / 2023);
            if (GetOperationState(userService.Register(email, password)) == false)
                Assert.Fail("Register failed");
            if (GetOperationState(boardControllerService.AddBoard(email, boardName)) == false)
                Assert.Fail("AddBoard failed");
            if (GetOperationState(boardService.AddTask(email, boardName, taskTitle, description, dueDate)) == false)
                Assert.Fail("AddTask failed"); ;
            string result = boardService.AdvanceTask(email, boardName, 0, 0);
            string query = "SELECT * FROM Tasks WHERE State=1";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void ChangeTitleTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            string taskTitle = "task1";
            string description = "desc1";
            string newTitle = "newTitle";
            DateTime dueDate = new DateTime(20 / 05 / 2023);
            if (GetOperationState(userService.Register(email, password)) == false)
                Assert.Fail("Register failed");
            if (GetOperationState(boardControllerService.AddBoard(email, boardName)) == false)
                Assert.Fail("AddBoard failed");
            if (GetOperationState(boardService.AddTask(email, boardName, taskTitle, description, dueDate)) == false)
                Assert.Fail("AddTask failed"); ;
            string result = taskService.UpdateTaskTitle(email, boardName, 0, 0, newTitle);
            string query = $"SELECT * FROM Tasks WHERE Title='{newTitle}";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void ChangeDescriptionTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            string taskTitle = "task1";
            string description = "desc1";
            string newDescription = "desc2";
            DateTime dueDate = new DateTime(20 / 05 / 2023);
            if (GetOperationState(userService.Register(email, password)) == false)
                Assert.Fail("Register failed");
            if (GetOperationState(boardControllerService.AddBoard(email, boardName)) == false)
                Assert.Fail("AddBoard failed");
            if (GetOperationState(boardService.AddTask(email, boardName, taskTitle, description, dueDate)) == false)
                Assert.Fail("AddTask failed"); ;
            string result = taskService.UpdateTaskDescription(email, boardName, 0, 0, newDescription);
            string query = $"SELECT * FROM Tasks WHERE Description='{newDescription}";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void ChangeAssigneeTestOwner()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            string taskTitle = "task1";
            string description = "desc1";;
            DateTime dueDate = new DateTime(20 / 05 / 2023);
            if (GetOperationState(userService.Register(email, password)) == false)
                Assert.Fail("Register failed");
            if (GetOperationState(boardControllerService.AddBoard(email, boardName)) == false)
                Assert.Fail("AddBoard failed");
            if (GetOperationState(boardService.AddTask(email, boardName, taskTitle, description, dueDate)) == false)
                Assert.Fail("AddTask failed"); ;
            string result = taskService.AssignTask(email, boardName, 0, 0, email);
            string query = $"SELECT * FROM Task WHERE Assignee='{email}";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void ChangeAssigneeTestNewAssignee()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string email2 = "Hadaspr100@gmail.com";
            string password2 = "Printz1234";
            string boardName = "board1";
            string taskTitle = "task1";
            string description = "desc1";
            DateTime dueDate = new DateTime(20 / 05 / 2023);
            if (GetOperationState(userService.Register(email, password)) == false)
                Assert.Fail("Register failed");
            if (GetOperationState(boardControllerService.AddBoard(email, boardName)) == false)
                Assert.Fail("AddBoard failed");
            if (GetOperationState(boardService.AddTask(email, boardName, taskTitle, description, dueDate)) == false)
                Assert.Fail("AddTask failed");
            if (GetOperationState(taskService.AssignTask(email, boardName, 0, 0, email))==false)
                Assert.Fail("AssignTask failed");
            if(GetOperationState(userService.Register(email2, password2))==false)
                Assert.Fail("Register failed");
            string result = taskService.AssignTask(email, boardName, 0, 0, email2); 
            string query = $"SELECT * FROM Task WHERE Assignee='{email2}";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void ChangeDueDateTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            string taskTitle = "task1";
            string description = "desc1";
            DateTime dueDate = new DateTime(20 / 05 / 2023);
            DateTime dueDate2 = new DateTime(20 / 05 / 2024);
            if (GetOperationState(userService.Register(email, password)) == false)
                Assert.Fail("Register failed");
            if (GetOperationState(boardControllerService.AddBoard(email, boardName)) == false)
                Assert.Fail("AddBoard failed");
            if (GetOperationState(boardService.AddTask(email, boardName, taskTitle, description, dueDate)) == false)
                Assert.Fail("AddTask failed");
            string result = taskService.UpdateTaskDueDate(email, boardName, 0, 0, dueDate2);
            string query = $"SELECT * FROM Tasks WHERE DueDate='{dueDate2}";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        private static bool GetOperationState(string json)
        {
            Response<object> res = JsonController.BuildFromJson<Response<object>>(json);
            if (res.operationState == true)
            {
                return true;
            }
            else return false;
        }
    }
}