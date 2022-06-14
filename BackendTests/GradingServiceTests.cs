using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroSE.Kanban.Backend.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.Utilities;

namespace IntroSE.Kanban.Backend.ServiceLayer.Tests
{
    [TestClass()]
    public class GradingServiceTests
    {
        GradingService gs;

        [TestMethod()]
        public void GradingService_Test()
        {
            gs = new();
            gs.DeleteData();
        }

        [TestMethod()]
        public void Change_Owner_After()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Login_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Logout_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LimitColumn_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetColumnLimit_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetColumnName_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTask_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTaskDueDate_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTaskTitle_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTaskDescription_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AdvanceTask_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetColumn_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBoard_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveBoard_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InProgressTasks_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUserBoards_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void JoinBoard_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LeaveBoard_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AssignTask_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadData_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteData_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TransferOwnership_Test()
        {
            Assert.Fail();
        }


        public bool TOF(string json)
        {
            GradingResponse<string> res = JsonController.BuildFromJson<GradingResponse<string>>(json);
            return res.ErrorMessage == null;
        }
        public T ReturnValue<T>(string json)
        {
            GradingResponse<T> res = JsonController.BuildFromJson<GradingResponse<T>>(json);
            return res.ReturnValue;
        }
    }
}