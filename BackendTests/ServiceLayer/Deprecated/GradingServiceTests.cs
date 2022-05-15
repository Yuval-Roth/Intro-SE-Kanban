//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using IntroSE.Kanban.Backend.ServiceLayer;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

//namespace IntroSE.Kanban.Backend.ServiceLayer.Tests
//{
//    [TestClass()]
//    public class GradingServiceTests
//    {
//        GradingService service = new GradingService();

//        [TestMethod()]
//        //Registration success
//        public void RegisterTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
//            Assert.AreEqual(expected, result);
//        }
//        //user exist in the system
//        [TestMethod()]
//        public void RegisterTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"Element already exists in the tree"));
//            string result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
//            result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
//            Assert.AreEqual(expected, result);
//        }
//        //invalid password
//        [TestMethod()]
//        public void RegisterTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"Password illegal"));
//            string result = service.Register("yuval@post.bgu.ac.il", "a12345");
//            Assert.AreEqual(expected, result);
//        }
//        //null email
//        [TestMethod()]
//        public void RegisterTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"Email is null"));
//            string result = service.Register(null, "Ha12345");
//            Assert.AreEqual(expected, result);
//        }
//        //null password
//        [TestMethod()]
//        public void RegisterTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"Password is null"));
//            string result = service.Register("yuval@post.bgu.ac.il", null);
//            Assert.AreEqual(expected, result);
//        }

//        [TestMethod()]
//        //LogIn success
//        public void LogInTest()
//        {
//            service.Register("printz@post.bgu.il", "Hadas12345");
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Login("printz@post.bgu.il", "Hadas12345");
//            Assert.AreEqual(expected, result);
//        }
//        //incorrect password
//        [TestMethod()]
//        public void LogInTest1()
//        {
//            service.Register("printz@post.bgu.il", "Hadas12345");
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"Incorrect Password"));
//            string result = service.Login("printz@post.bgu.il", "Hadas6789");
//            Assert.AreEqual(expected, result);
//        }
//        //user doesn't exist
//        [TestMethod()]
//        public void LogInTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"There is no such user in the system"));
//            string result = service.Login("printz@post.bgu.il", "Hadas12345");
//            Assert.AreEqual(expected, result);
//        }
//        //user allready loggedIn
//        [TestMethod()]
//        public void LogInTest3()
//        {
//            service.Register("printz@post.bgu.il", "Hadas12345");
//            service.Login("printz@post.bgu.il", "Hadas12345");
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"User is already logged in"));
//            string result = service.Login("printz@post.bgu.il", "Hadas12345");
//            Assert.AreEqual(expected, result);
//        }
//        //null email
//        [TestMethod()]
//        public void LogInTest4()
//        {
//            service.Register("printz@post.bgu.il", "Hadas12345");
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"Email is null"));
//            string result = service.Login(null, "Hadas12345");
//            Assert.AreEqual(expected, result);
//        }
//        //null password
//        [TestMethod()]
//        public void LogInTest5()
//        {
//            service.Register("printz@post.bgu.il", "Hadas12345");
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"Password is null"));
//            string result = service.Login("printz@post.bgu.il", null);
//            Assert.AreEqual(expected, result);
//        }

 
//        //logOut successesful
//        [TestMethod()]
//        public void LogOutTest()
//        {
//            service.Register("printz@post.bgu.il", "Hadas12345");
//            service.Login("printz@post.bgu.il", "Hadas12345");
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Logout("printz@post.bgu.il");
//            Assert.AreEqual(expected, result);

//        }
//        //user isn't loggedIn
//        [TestMethod()]
//        public void LogOutTest1()
//        {
//            service.Register("printz@post.bgu.il", "Hadas12345");
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"User isn't loggedIn"));
//            string result = service.Logout("printz@post.bgu.il");
//            Assert.AreEqual(expected, result);

//        }
//        //null user
//        [TestMethod()]
//        public void LogOutTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"User is null"));
//            string result = service.Logout(null);
//            Assert.AreEqual(expected, result);

//        }

//        //successful
//        [TestMethod()]
//        public void LimitColumnTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //user isn't exist
//        [TestMethod()]
//        public void LimitColumnTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
//            string result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void LimitColumnTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //borard isn't exist
//        [TestMethod()]
//        public void LimitColumnTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //column isn't exist
//        [TestMethod()]
//        public void LimitColumnTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 5, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //column has more tasks than the limit
//        [TestMethod()]
//        public void LimitColumnTest5()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column has more tasks than the limit"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 2", "ni ni ni", new DateTime());
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //successful
//        [TestMethod()]
//        public void GetColumnLimitTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<object>(true,new object()));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            result = service.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //user isn't exist
//        [TestMethod()]
//        public void GetColumnLimitTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
//            string result = service.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void GetColumnLimitTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //board isn't exist
//        [TestMethod()]
//        public void GetColumnLimitTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //column isn't exist
//        [TestMethod()]
//        public void GetColumnLimitTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            result = service.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 7);
//            Assert.AreEqual(expected, result);
//        }

//        //column is unlimited
//        [TestMethod()]
//        public void GetColumnLimitTest5()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column is unlimited"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.GetColumnLimit("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //successful
//        [TestMethod()]
//        public void GetColumnNameTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<object>(true,new object()));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //user isn't exist
//        [TestMethod()]
//        public void GetColumnNameTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
//            string result = service.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void GetColumNameTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //board isn't exist
//        [TestMethod()]
//        public void GetColumnNameTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //column isn't exist
//        [TestMethod()]
//        public void GetColumnNameTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.GetColumnName("kfirniss@post.bgu.ac.il", "new board", 7);
//            Assert.AreEqual(expected, result);
//        }

//        //successful
//        [TestMethod()]
//        public void AddTaskTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't exist
//        [TestMethod()]
//        public void AddTaskTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't exist"));
//            string result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void AddTaskTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //board isn't exist
//        [TestMethod()]
//        public void AddTaskTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //column can't over the limit
//        [TestMethod()]
//        public void AddTaskTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column can't over the limit"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "ni ni ni", new DateTime());
//            Assert.AreEqual(expected, result);
//        }


//        //successful
//        [TestMethod()]
//        public void UpdateTaskDueDateTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //user isn't exist
//        [TestMethod()]
//        public void UpdateTaskDueDateTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
//            string result = service.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void UpdateTaskDueDateTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //board isn't exist
//        [TestMethod()]
//        public void UpdateTaskDueDateTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 1, new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //column isn't exist
//        [TestMethod()]
//        public void UpdateTaskDueDateTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 5, 1, new DateTime());
//            Assert.AreEqual(expected, result);
//        }

//        //task isn't exist
//        [TestMethod()]
//        public void UpdateTaskDueDateTest5()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"task isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskDueDate("kfirniss@post.bgu.ac.il", "new board", 0, 5, new DateTime());
//            Assert.AreEqual(expected, result);
//        }


//        //successful
//        [TestMethod()]
//        public void UpdateTaskTitleTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1,"new task title name");
//            Assert.AreEqual(expected, result);
//        }

//        //user isn't exist
//        [TestMethod()]
//        public void UpdateTaskTitleTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
//            string result = service.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void UpdateTaskTitleTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
//            Assert.AreEqual(expected, result);
//        }

//        //board isn't exist
//        [TestMethod()]
//        public void UpdateTaskTitleTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
//            Assert.AreEqual(expected, result);
//        }

//        //column isn't exist
//        [TestMethod()]
//        public void UpdateTaskTitleTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
//            Assert.AreEqual(expected, result);
//        }

//        //task isn't exist
//        [TestMethod()]
//        public void UpdateTaskTitleTest5()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"task isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskTitle("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task title name");
//            Assert.AreEqual(expected, result);
//        }

//        //successful
//        [TestMethod()]
//        public void UpdateTaskDescriptionTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
//            Assert.AreEqual(expected, result);
//        }

//        //user isn't exist
//        [TestMethod()]
//        public void UpdateTaskDescriptionTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
//            string result = service.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void UpdateTaskDescriptionTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
//            Assert.AreEqual(expected, result);
//        }

//        //board isn't exist
//        [TestMethod()]
//        public void UpdateTaskDescriptionTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
//            Assert.AreEqual(expected, result);
//        }

//        //column isn't exist
//        [TestMethod()]
//        public void UpdateTaskDescriptionTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
//            Assert.AreEqual(expected, result);
//        }

//        //task isn't exist
//        [TestMethod()]
//        public void UpdateTaskDescriptionTest5()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"task isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.UpdateTaskDescription("kfirniss@post.bgu.ac.il", "new board", 0, 1, "new task description");
//            Assert.AreEqual(expected, result);
//        }

//        //successful
//        [TestMethod()]
//        public void AdvanceTaskTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't exist
//        [TestMethod()]
//        public void AdvanceTaskTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't exist"));
//            string result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void AdvanceTaskTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //board isn't exist
//        [TestMethod()]
//        public void AdvanceTaskTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //task isn't exist in the column
//        [TestMethod()]
//        public void AdvanceTaskTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"task isn't exist in the column"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //task is done
//        [TestMethod()]
//        public void AdvanceTaskTest5()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"task is done"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 1, 1);
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 2, 1);
//            Assert.AreEqual(expected, result);
//        }

//        //column can't over the limit
//        [TestMethod()]
//        public void AdvanceTaskTest6()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column can't over the limit"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 2", "ni ni ni", new DateTime());
//            result = service.LimitColumn("kfirniss@post.bgu.ac.il", "new board", 1, 1);
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 2);
//            Assert.AreEqual(expected, result);
//        }

//        //successful
//        [TestMethod()]
//        public void GetColumnTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<object>(true,new object()));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.GetColumn("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //user isn't exist
//        [TestMethod()]
//        public void GetColumnTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user isn't exist"));
//            string result = service.GetColumn("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void GetColumnTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.GetColumn("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //board isn't exist
//        [TestMethod()]
//        public void GetColumnTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.GetColumn("kfirniss@post.bgu.ac.il", "new board", 0);
//            Assert.AreEqual(expected, result);
//        }

//        //column isn't exist
//        [TestMethod()]
//        public void GetColumnTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column isn't exist"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.GetColumn("kfirniss@post.bgu.ac.il", "new board", 5);
//            Assert.AreEqual(expected, result);
//        }

//        //column is empty
//        [TestMethod()]
//        public void GetColumnTest5()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"column is empty"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.GetColumn("kfirniss@post.bgu.ac.il", "new board", 1);
//            Assert.AreEqual(expected, result);
//        }

//        //create successful
//        [TestMethod()]
//        public void AddBoardTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't exist
//        [TestMethod()]
//        public void AddBoardTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't exist!"));
//            string result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void AddBoardTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false, "user doesn't login!"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            Assert.AreEqual(expected, result);
//        }

//        //board already existed
//        [TestMethod()]
//        public void AddBoardTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board already existed!"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            Assert.AreEqual(expected, result);
//        }

//        //Delete successful
//        [TestMethod()]
//        public void RemoveBoardTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't exist 
//        [TestMethod()]
//        public void RemoveBoardTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't exist!"));
//            string result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void RemoveBoardTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login!"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
//            Assert.AreEqual(expected, result);
//        }

//        //user has no boards to delete
//        [TestMethod()]
//        public void RemoveBoardTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user has no boards to delete!"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "new board");
//            Assert.AreEqual(expected, result);
//        }

//        //board doesn't exist
//        [TestMethod()]
//        public void RemoveBoardTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"board doesn't exist!"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.RemoveBoard("kfirniss@post.bgu.ac.il", "other board");
//            Assert.AreEqual(expected, result);
//        }

//        //successful
//        [TestMethod()]
//        public void InProgressTasksTest()
//        {
//            string expected = JsonController.ConvertToJson(new Response<object>(true,new object()));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "another board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime());
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "new board", 0, 1);
//            result = service.AdvanceTask("kfirniss@post.bgu.ac.il", "another board", 0, 1);
//            result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
//            Assert.AreEqual(expected, result);
//        }

//        //user dosen't exist
//        [TestMethod()]
//        public void InProgressTasksTest1()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't exist!"));
//            string result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
//            Assert.AreEqual(expected, result);
//        }

//        //user doesn't login
//        [TestMethod()]
//        public void InProgressTasksTest2()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user doesn't login"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
//            Assert.AreEqual(expected, result);
//        }

//        //user has no boards
//        [TestMethod()]
//        public void InProgressTasksTest3()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user has no boards"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
//            Assert.AreEqual(expected, result);
//        }

//        //user has no inprogress tasks
//        [TestMethod()]
//        public void InProgressTasksTest4()
//        {
//            string expected = JsonController.ConvertToJson(new Response<string>(false,"user has no inprogress tasks"));
//            string result = service.Register("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.Login("kfirniss@post.bgu.ac.il", "Ha12345");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "new board");
//            result = service.AddBoard("kfirniss@post.bgu.ac.il", "another board");
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "new board", "task 1", "bla bla bla", new DateTime());
//            result = service.AddTask("kfirniss@post.bgu.ac.il", "another board", "task 2", "ninini", new DateTime());
//            result = service.InProgressTasks("kfirniss@post.bgu.ac.il");
//            Assert.AreEqual(expected, result);
//        }

//    }
//}