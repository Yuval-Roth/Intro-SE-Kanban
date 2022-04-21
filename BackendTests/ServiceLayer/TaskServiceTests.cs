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
        BoardService boardService = new BoardService();
        TaskService taskService = new TaskService();
        BusinessLayer.Date dueDate = new("25/6/2022");

        [TestMethod()]
        public void GetTitleTest1()
        {
            boardService.AddTask("test", dueDate, "JustTestin");
            string title = taskService.GetTitle();

            string expected = new Response(true, "JustTestin").GenerateJson();
            string result = boardService.get
        }

        [TestMethod()]
        public void SetTitleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDuedateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetDuedateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDescriptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetDescriptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetStateTest()
        {
            Assert.Fail();
        }
    }
}