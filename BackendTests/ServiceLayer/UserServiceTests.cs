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

        [TestMethod()]
        public void UserServiceTest()
        {
            Assert.AreEqual();
                
        }
        //successful registration
        [TestMethod()]
        public void registerTest1()
        {
            string expected = new Response(true, "Registration successful!").GenerateJson();
            string result = service.register("yuval@post.bgu.ac.il", "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //user exist in the system
        [TestMethod()]
        public void RegisterTest2()
        {
            string expected = new Response(false, "User already exists").GenerateJson();
            string result = service.register("yuval@post.bgu.ac.il", "Ha12345");
            result = service.register("yuval@post.bgu.ac.il", "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //invalid password
        [TestMethod()]
        public void registerTest3()
        {
            string expected = new Response(false, "Invalid password").GenerateJson();
            string result = service.register("yuval@post.bgu.ac.il", "a12345");
            Assert.AreEqual(expected, result);
        }
        //null email
        [TestMethod()]
        public void registerTest4()
        {
            string expected = new Response(false, "Null email").GenerateJson();
            string result = service.register(null, "Ha12345");
            Assert.AreEqual(expected, result);
        }
        //null password
        [TestMethod()]
        public void registerTest5()
        {
            string expected = new Response(false, "Null password").GenerateJson();
            string result = service.register("yuval@post.bgu.ac.il", null);
            Assert.AreEqual(expected, result);
        }


        //delete successful
        [TestMethod()]
        public void deleteUserTest()
        {
            BusinessLayer.User newUser = new ("printz@post.bgu.il","Hadas12345");
            service.register("printz@post.bgu.il", "Hadas12345");
            string expected = new Response(true, "Delete successful!").GenerateJson();
            string result = service.deleteUser(newUser);
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void deleteUserTest1()
        {
            BusinessLayer.User newUser = new("printz@post.bgu.il", "Hadas12345");
            string expected = new Response(false, "User doesn't exist").GenerateJson();
            string result = service.deleteUser(newUser);
            Assert.AreEqual(expected, result);
        }
        //null user
        [TestMethod()]
        public void deleteUserTest2()
        {
            BusinessLayer.User newUser = null;
            string expected = new Response(false, "User is null").GenerateJson();
            string result = service.deleteUser(newUser);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void LogInTest()
        {
            
            Assert.Fail();
        }
        //logOut successesful
        [TestMethod()]
        public void logOutTest()
        {
            BusinessLayer.User newUser = new("printz@post.bgu.il", "Hadas12345");
            service.register("printz@post.bgu.il", "Hadas12345");
            service.logIn("printz@post.bgu.il", "Hadas12345");
            string expected = new Response(true, "loggedOut succssesful").GenerateJson();
            string result = service.logOut(newUser);
            Assert.AreEqual(expected, result);

        }
        //user isn't loggedIn
        [TestMethod()]
        public void logOutTest1()
        {
            BusinessLayer.User newUser = new("printz@post.bgu.il", "Hadas12345");
            service.register("printz@post.bgu.il", "Hadas12345");
            string expected = new Response(false, "User isn't loggedIn").GenerateJson();
            string result = service.logOut(newUser);
            Assert.AreEqual(expected, result);

        }
        //null user
        [TestMethod()]
        public void logOutTest2()
        {
            BusinessLayer.User newUser = null;
            string expected = new Response(false, "User isn't loggedIn").GenerateJson();
            string result = service.logOut(newUser);
            Assert.AreEqual(expected, result);

        }
        //successes
        //not register
        //password not same
        //





        [TestMethod()]
        public void SetPasswordTest()
        {
            Assert.Fail();
        }
        //setEnail successful
        [TestMethod()]
        public void SetEmailTest()
        {
            BusinessLayer.User newUser = new("printz@post.bgu.il", "Hadas12345");
            service.register("printz@post.bgu.il", "Hadas12345");
            string expected = new Response(true, "Email changed succesfull!").GenerateJson();
            string result = service.setEmail(newUser,"hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //user doesn't exist
        [TestMethod()]
        public void setEmailTest1()
        {
            BusinessLayer.User newUser = new("printz@post.bgu.il", "Hadas12345");
            string expected = new Response(false, "User doesn't exist").GenerateJson();
            string result = service.setEmail(newUser, "hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //email allready exist
        [TestMethod()]
        public void setEmailTest2()
        {
            BusinessLayer.User newUser = new("printz@post.bgu.il", "Hadas12345");
            BusinessLayer.User newUser2 = new("hadas@post.bgu.il", "Hadas6789");
            service.register("printz@post.bgu.il", "Hadas12345");
            service.register("hadas@post.bgu.il", "Hadas6789");
            string expected = new Response(false, "Email allreadt exist in the system").GenerateJson();
            string result = service.setEmail(newUser, "hadas@post.bgu.il");
            Assert.AreEqual(expected, result);
        }
        //null email
        [TestMethod()]
        public void setEmailTest3()
        {
            BusinessLayer.User newUser = new("printz@post.bgu.il", "Hadas12345");
            service.register("printz@post.bgu.il", "Hadas12345");
            string expected = new Response(false, "Email is null").GenerateJson();
            string result = service.setEmail(newUser, null);
            Assert.AreEqual(expected, result);
        }

    }
}