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
        UserService service = new UserService();
        BusinessLayer.UserController userController = new BusinessLayer.UserController();
        
        //successful registration
        [TestMethod()]
        public void RegisterTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(true, "Registration successful!"));
            string result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //user exist in the system
        [TestMethod()]
        public void RegisterTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "User already exists"));
            string result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            result = service.Register("yuval@post.bgu.ac.il", "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //invalid password
        [TestMethod()]
        public void RegisterTest3()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "Invalid password"));
            string result = service.Register("yuval@post.bgu.ac.il", "a12345");
            Assert.AreEqual(expected, result);
        }
        //null email
        [TestMethod()]
        public void RegisterTest4()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "Null email"));
            string result = service.Register(null, "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //null password
        [TestMethod()]
        public void RegisterTest5()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "Null password"));
            string result = service.Register("yuval@post.bgu.ac.il", null);
            Assert.AreEqual(expected, result);
        }


        //delete successful
        [TestMethod()]
        public void DeleteUserTest()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(true, "Delete successful!"));
            string result = service.DeleteUser("printz@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void DeleteUserTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "User doesn't exist"));
            string result = service.DeleteUser("printz@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //null user
        [TestMethod()]
        public void DeleteUserTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "User is null"));
            string result = service.DeleteUser(null);
            Assert.AreEqual(expected, result);
        }


        //user doesn't exist
        //pass incorrect
        //allready loggedIn
        //null email
        //null password
       
        //logIn successesful
        [TestMethod()]
        public void LogInTest()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(true, "loggedIn succssesful"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //incorrect password
        [TestMethod()]
        public void LogInTest1()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "Password incorrect"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas6789");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void LogInTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "User doesn't exist in the system"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //user allready loggedIn
        [TestMethod()]
        public void LogInTest3()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.LogIn("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "User allready loggedIn"));
            string result = service.LogIn("printz@post.bgu.il", "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null email
        [TestMethod()]
        public void LogInTest4()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "Email is null"));
            string result = service.LogIn(null, "Hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null password
        [TestMethod()]
        public void LogInTest5()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "Password is null"));
            string result = service.LogIn("printz@post.bgu.il", null);
            Assert.AreEqual(expected, result);
        }

        //logOut successesful
        [TestMethod()]
        public void logOutTest()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.LogIn("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(true, "loggedOut succssesful"));
            string result = service.LogOut("printz@post.bgu.il");
            Assert.AreEqual(expected, result);

        }
        //user isn't loggedIn
        [TestMethod()]
        public void LogOutTest1()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "User isn't loggedIn"));
            string result = service.LogOut("printz@post.bgu.il");
            Assert.AreEqual(expected, result);

        }
        //null user
        [TestMethod()]
        public void LogOutTest2()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "User isn't loggedIn"));
            string result = service.LogOut(null);
            Assert.AreEqual(expected, result);

        }
        //successes
        //not register
        //password not same
        //newpass illegal
        //null user
        //null oldpass
        //null newpass




        //successes serPassword
        [TestMethod()]
        public void SetPasswordTest()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(true, "SetPassword successesful!"));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas12345","Printz12345");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void SetPasswordTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "User doesn't exist in the system"));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas12345", "Printz12345");
            Assert.AreEqual(expected, result);
        }
        //checkMatchPassword fail
        [TestMethod()]
        public void SetPasswordTest2()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "Old password incorrect"));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas6789", "Printz12345");
            Assert.AreEqual(expected, result);
        }
        //new password illegal
        [TestMethod()]
        public void SetPasswordTest3()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "New password is Illegal"));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas12345", "hadas12345");
            Assert.AreEqual(expected, result);
        }
        //null user
        [TestMethod()]
        public void SetPasswordTest4()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "User is null"));
            string result = service.SetPassword(null, "Hadas12345", "Printz12345");
            Assert.AreEqual(expected, result);
        }
        //null old password
        [TestMethod()]
        public void SetPasswordTest5()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "Old password is null"));
            string result = service.SetPassword("printz@post.bgu.il", null, "Printz12345");
            Assert.AreEqual(expected, result);
        }
        //null new password
        [TestMethod()]
        public void SetPasswordTest6()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "New password is null"));
            string result = service.SetPassword("printz@post.bgu.il", "Hadas12345", null);
            Assert.AreEqual(expected, result);
        }




        //setEnail successful
        [TestMethod()]
        public void SetEmailTest()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(true, "Email changed succesfull!"));
            string result = service.SetEmail("printz@post.bgu.il", "hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void SetEmailTest1()
        {
            string expected = JsonController.ConvertToJson(new Response(false, "User doesn't exist"));
            string result = service.SetEmail("printz@post.bgu.il", "hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //email allready exist
        [TestMethod()]
        public void SetEmailTest2()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            service.Register("hadas@post.bgu.il", "Hadas6789");
            string expected = JsonController.ConvertToJson(new Response(false, "Email allreadt exist in the system"));
            string result = service.SetEmail("printz@post.bgu.il", "hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //null email
        [TestMethod()]
        public void SetEmailTest3()
        {
            service.Register("printz@post.bgu.il", "Hadas12345");
            string expected = JsonController.ConvertToJson(new Response(false, "Email is null"));
            string result = service.SetEmail("printz@post.bgu.il", null);
            Assert.AreEqual(expected, result);
        }

    }
}