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
        CIString email1 = "printz@post.bgu.ac.il";
        CIString email2 = "hadaspr100@gmail.com";
        CIString password1 = "Hadas1234";
        CIString password2 = "Printz1234";
        CIString boardName1 = "board1";
        CIString boardName2 = "board2";
        CIString title1 = "task1";
        CIString title2 = "task2";
        CIString title3 = "task3";
        CIString desc1 = "1bla";
        CIString desc2 = "2bla";
        CIString desc3 = "3bla";
        //DateTime cre1 = new DateTime(2022, 06, 15);
        //DateTime cre2 = new DateTime(2022, 06, 15);
        //DateTime cre3 = new DateTime(2022, 06, 15);
        DateTime due1 = new DateTime(2023, 06, 15);
        DateTime due2 = new DateTime(2023, 06, 15);
        DateTime due3 = new DateTime(2023, 06, 15);

        [TestMethod()]
        public void GradingService_Test()
        {
            gs = new();
            gs.DeleteData();
        }

        [TestMethod()]
        public void Change_Owner_User_Isnt_Joined()       
        {
            gs.Register(email1, password1);
            gs.AddBoard(email1, boardName1);
            gs.Register(email2, password2);
            string result = gs.TransferOwnership(email1, email2, boardName1);
            Assert.AreEqual(TOF(result),false);
        }


        [TestMethod()]
        public void Change_Owner_User_Joined_With_Tasks()
        {
            gs.Register(email1, password1);
            gs.AddBoard(email1, boardName1);
            gs.AddTask(email1, boardName1, title1, desc1, due1);
            gs.AssignTask(email1, boardName1, 0, 0, email1);
            gs.Register(email2, password2);
            string result = gs.TransferOwnership(email1, email2, boardName1);
            Assert.AreEqual(TOF(result), true);
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