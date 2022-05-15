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

    public class UserServiceTests
    {
        UserService service;
        BusinessLayer.UserData userData;

        public UserServiceTests() 
        {
            userData = new();
            service = new UserService(userData);
        }

        [TestMethod()]
        public void RegisterTestSuccess()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //user exist in the system
        [TestMethod()]
        public void RegisterTestExistUser()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false, "A user whith that yuval@post.bgu.ac.il already exist in the system"));
            string result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //invalid password
        [TestMethod()]
        public void RegisterTestIllegalPassword()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"Password illegal"));
            string result = service.Register("yuval@post.bgu.ac.il", "a12345");
            Assert.AreEqual(expected, result);
        }
        //null email
        //[TestMethod()]
        //public void RegisterTestNullEmail()
        //{
          //  string expected = JsonController.ConvertToJson(new Response<string>(false,"Email is null"));;
            //string result = service.Register(null, "Ha12345");
            //Assert.AreEqual(expected, result);
        //}
        //null password
        //[TestMethod()]
       // public void RegisterTestNullPassword()
       // {
         //   string expected = JsonController.ConvertToJson(new Response<string>(false,"Password is null"));
         //   string result = service.Register("yuval@post.bgu.ac.il", null);
         //   Assert.AreEqual(expected, result);
      //  }


        //delete successful
        [TestMethod()]
        public void DeleteUserTestSuccess()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = service.DeleteUser("printz@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void DeleteUserTestUserDoesntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"User with 'printz@post.bgu.il' doesn't exist in the system"));
            string result = service.DeleteUser("printz@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //null user
       // [TestMethod()]
       // public void DeleteUserTestNullUser()
       // {
          //  string expected = JsonController.ConvertToJson(new Response<string>(false,"User is null"));
          //  string result = service.DeleteUser(null);
          //  Assert.AreEqual(expected, result);
      //  }


        //user doesn't exist
        //pass incorrect
        //allready loggedIn
        //null email
        //null password
       
        //logIn successesful
        [TestMethod()]
        public void LogInTestSuccess()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //incorrect password
        [TestMethod()]
        public void LogInTestIncorrectPassword()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(false,"Incorrect Password"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas6789");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void LogInTestUserDoesntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"A user with the email printz@post.bgu.il doesn't exist in the system"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //user allready loggedIn
        [TestMethod()]
        public void LogInTestUserLoggedIn()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.LogIn("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(false,"The user with the email printz@post.bgu.il is already logged in"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null email
       // [TestMethod()]
       // public void LogInTestNullEmail()
      //  {
        //    service.Register("printz@post.bgu.il", "Hadas12345");
         //   string expected = JsonController.ConvertToJson(new Response<string>(false,"Email is null"));
         //   string result = service.LogIn(null, "Hadas12345");
         //   Assert.AreEqual(expected, result);
       // }
        //null password
        //[TestMethod()]
      //  public void LogInTestNullPassword()
        //{
         //   service.Register("printz@post.bgu.il", "Hadas12345");
           // string expected = JsonController.ConvertToJson(new Response<string>(false,"Password is null"));
          //  string result = service.LogIn("printz@post.bgu.il", null);
          //  Assert.AreEqual(expected, result);
       // }

        //logOut successesful
        [TestMethod()]
        public void logOutTestSuccess()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.LogIn("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = service.LogOut("printz@post.bgu.il");
            Assert.AreEqual(expected, result);

        }
        //user isn't loggedIn
        [TestMethod()]
        public void LogOutTestUserIsntLoggedIn()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(false,"User isn't loggedIn"));
            string result = service.LogOut("printz@post.bgu.il");
            Assert.AreEqual(expected, result);

        }
        //null user
       // [TestMethod()]
       // public void LogOutTestNullUser()
       // {
          //  string expected = JsonController.ConvertToJson(new Response<string>(false,"User is null"));
           // string result = service.LogOut(null);
          //  Assert.AreEqual(expected, result);

      //  }
        //successes
        //not register
        //password not same
        //newpass illegal
        //null user
        //null oldpass
        //null newpass




        //successes serPassword
        [TestMethod()]
        public void SetPasswordTestSuccess()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas12345","Printz12345");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void SetPasswordTestUserIsntInTheSystem()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"User is not in the system"));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas12345", "Printz12345");
            Assert.AreEqual(expected, result);
        }
        //checkMatchPassword fail
        [TestMethod()]
        public void SetPasswordTestOldPasswordIncorrect()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(false,"Old Password incorrect"));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas6789", "Printz12345");
            Assert.AreEqual(expected, result);
        }
        //new password illegal
        [TestMethod()]
        public void SetPasswordTestNewPasswordIllegal()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(false,"New password is illegal"));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas12345", "hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null user
        //[TestMethod()]
        //public void SetPasswordTestNullUser()
       // {
          //  service.Register("printz@post.bgu.il", "Hadas12345");
          //  string expected = JsonController.ConvertToJson(new Response<string>(false,"User is null"));
         //   string result = service.SetPassword(null, "Hadas12345", "Printz12345");
         //  Assert.AreEqual(expected, result);
       // }
        //null old password
        //[TestMethod()]
        //public void SetPasswordTestNullOldPassword()
        //{
           // service.Register("printz@post.bgu.il", "Hadas12345");
           // string expected = JsonController.ConvertToJson(new Response<string>(false,"Old password is null"));
           // string result = service.SetPassword("printz@post.bgu.il", null, "Printz12345");
           // Assert.AreEqual(expected, result);
       // }
        //null new password
       // [TestMethod()]
        //public void SetPasswordTestNullNewPassword()
       // {
          //  service.Register("printz@post.bgu.il", "Hadas12345");
           // string expected = JsonController.ConvertToJson(new Response<string>(false,"New password is null"));
          //  string result = service.SetPassword("printz@post.bgu.il", "Hadas12345", null);
          //  Assert.AreEqual(expected, result);
       // }




        //setEnail successful
        [TestMethod()]
        public void SetEmailTestSuccess()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response<string>(true,""));
            string result = service.SetEmail("printz@post.bgu.il", "hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void SetEmailTestUserDoesntExist()
        {
            string expected = JsonController.ConvertToJson(new Response<string>(false,"User dosen't exist"));
            string result = service.SetEmail("printz@post.bgu.il", "hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //email allready exist
        [TestMethod()]
        public void SetEmailTestEmailExist()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.Register("hadas@post.bgu.il", "Hadas6789");
            string expected = JsonController.ConvertToJson(new Response<string>(false,"A user with that email already exists in the system"));
            string result = service.SetEmail("printz@post.bgu.il", "hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //null email
        //[TestMethod()]
       // public void SetEmailTestNullEmail()
        //{
          //  service.Register("printz@post.bgu.il", "Hadas12345");
          //  string expected = JsonController.ConvertToJson(new Response<string>(false,"New email is null"));
          //  string result = service.SetEmail("printz@post.bgu.il", null);
         //  Assert.AreEqual(expected, result);
       // }

    }
}