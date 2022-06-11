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
    public class UserControllerDTOTests
    {
        UserService service;
        SQLExecuter executer;

        public UserControllerDTOTests()
        {
            Backend.BusinessLayer.BusinessLayerFactory.GetInstance().DataCenterManagement.DeleteData();
            ServiceLayerFactory.DeleteEverything();
            ServiceLayerFactory ServiceFactory = ServiceLayerFactory.GetInstance();
            DataAccessLayerFactory DataFactory = DataAccessLayerFactory.GetInstance();
            service = ServiceFactory.UserService;
            executer = DataFactory.SQLExecuter;
        }


        [TestMethod()]
        public void AddUserTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string result = service.Register(email, password);
            string query = $"SELECT * FROM Users WHERE Email='{email}'";
            if (GetOperationState(result)== false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }


        //[TestMethod()]
        //public void DeleteUserTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void ChangePasswordTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string newPassword = "Printz1234";
            if(GetOperationState(service.Register(email, password))==false)
                Assert.Fail("Register failed");
            string result = service.SetPassword(email, password, newPassword);
            string query = $"SELECT Password FROM Users WHERE Email='{email}'";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
                if (reader.GetString(0) != newPassword) Assert.Fail("change password incorrectly");
            }
        }

        [TestMethod()]
        public void ChangeEmailTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string newEmail = "Hadaspr100@gmail.com";
            if (GetOperationState(service.Register(email, password)) == false)
                Assert.Fail("Register failed");
            string result = service.SetEmail(email, newEmail);
            string query = $"SELECT Email FROM Users WHERE Email='{newEmail}'";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
                if (reader.GetString(0) != newEmail) Assert.Fail("change email incorrectly");
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