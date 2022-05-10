﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;


namespace IntroSE.Kanban.Backend.BusinessLayer
{

    /// <summary>
    ///This class controls the actions operated by the user.<br/>
    ///<br/>
    ///<code>Supported operations:</code>
    ///<br/>
    /// <list type="bullet">Register()</list>
    /// <list type="bullet">DeleteUser()</list>
    /// <list type="bullet">LogIn()</list>
    /// <list type="bullet">LogOut()</list>
    /// <list type="bullet">SetPassword()</list>
    /// <list type="bullet">SetEmail()</list>
    /// <list type="bullet">SearchUser()</list>
    /// <list type="bullet">IsLegalPassword()</list>
    /// <br/><br/>
    /// ===================
    /// <br/>
    /// <c>Ⓒ Hadas Printz</c>
    /// <br/>
    /// ===================
    /// </summary>
    public class UserController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\UserController.cs");

        private UserData userData;
        private static readonly int MIN_PASS_LENGTH = 6;
        private static readonly int MAX_PASS_LENGTH = 20;

        /// <summary>
        /// Creates an empty <c>BinaryTree</c> userList <br/>
        /// Creates an empty <c>Dictionary</c> loggedIn
        /// </summary>
        public UserController(UserData userData)
        {
            this.userData = userData; 
        }

        /// <summary>
        /// Add new <c>User</c> to <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>ArgumentNullException</c> if email or password entered are null <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user allready exists or if the password entered is illegal
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>

        public void Register(string email, string password)
        {
            log.Debug("Register() for: " + email);
            if (email == null){
                log.Error("Register() failed: '" + email + "' is null");
                throw new ArgumentNullException ("Email is null"); }
            if(password == null){
                log.Error("Register() failed: '" + password + "' is null");
                throw new ArgumentNullException("Password is null"); }
            if (!IsLegalPassword(password)) {
                log.Error("Register() failed: '" + password + "' is illegal");
                throw new ArgumentException("Password illegal"); }
            try
            {
                userData.AddUser(email,password);
                log.Debug("Register() success");
            }
            catch (ArgumentException)
            {
                log.Error("Register() failed: '" + email + "' already exist in the system");
                throw new ArgumentException("A user whith that " + email +
                    " already exist in the system");
            }
            
        }

        /// <summary>
        ///Delate <c>User</c> from the <c>UserData</c> userData <br/> <br/>
        ///<b>Throws</b> <c>ArgumentNullException</c> if the user entered is null <br/>
        ///<b>Throws</b> <c>NoSuchElementException</c> if the user doesn't exist in the userData
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void DeleteUser(User user)
        {
            log.Debug("DeleteUser() for: " + user);
            if (user == null)
            {
                log.Error("DeleteUser() failed: '" + user + "' is null");
                throw new ArgumentNullException("User is null");
            }
            try
            {
                userData.RemoveUser(user.GetEmail());
                log.Debug("DeleteUser() success");
            }
            catch (NoSuchElementException)
            {
                log.Error("DeleteUser() failed: " + user + " doesn't exist in the system");
                throw new NoSuchElementException(user + " doesn't exist in the system");
            }
        }

        /// <summary>
        /// Log in User to the system-Add user to <c>Dictionary</c> loogedIn <br/><br/>
        /// <b>Throws</b> <c>ArgumentNullException</c> if email or password entered are null <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user is allready loggedIn or <br/> if user with those email and password doesn't exist <br/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void LogIn(string email, string password)
        {
            log.Debug("LogIn() for: " + email);
            if (password == null)
            {
                log.Error("LogIn() failed: '" + password + "' is null");
                throw new ArgumentNullException("Password is null");
            }
            if (email == null)
            {
                log.Error("LogIn() failed: '" + email + "' is null");
                throw new ArgumentNullException("Email is null");
            }
            if (userData.ContainsUser(email))
            {
                if (userData.SearchUser(email).CheckPasswordMatch(password))
                {
                    try
                    {
                        userData.SetLoggedIn(email);
                        log.Debug("LogIn() success");
                    }
                    catch(ArgumentException)
                    {
                        log.Error("LogIn() failed: user with '" + email + "' allready loggedIn");
                        throw new ArgumentException("A user with '" + email + "' allready loggedIn");
                    }      
                }
                else
                {
                    log.Error("LogIn() failed: " + password + "incorrect");
                    throw new ArgumentException("Incorrect Password");
                }
            }
            else
            {
                log.Error("LogIn() failed: there is no user with " + email + " in the system");
                throw new ArgumentException("There is no such user in the system");  
            }
        }

        /// <summary>
        /// Log out user from the system- Remove user from <c>Dictionary</c> loogedIn <br/><br/>
        /// <b>Throws</b> <c>ArgumentNullException</c> if the user entered is null <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user isn't logged in
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>

        public void LogOut(User user)
        {
            log.Debug("LogOut() for " + user);
            if (user == null)
            {
                log.Error("LogOut() failed: '" + user + "' is null");
                throw new ArgumentNullException("User is null");
            }
            try
            {
                userData.SetLoggedOut(user.GetEmail());
                log.Debug("LogOut() success");
            }
            catch (ArgumentException)
            {
                log.Error("LogOut() failed: " + user + "is not logget in");
                throw new ArgumentException(user + " is not logged in");
            }
            
        }

        /// <summary>
        /// Replace the user's password after ensuring the user entered his old password correctly <br/><br/>
        /// <b>Throws</b> <c>ArgumentNullException</c> if the user/ old password/ new password are null <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user doesn't exist in the system <b>or</b> <br/> if the new password entered is illegal <b>or</b> <br/> if the old password entered doesn't match the user's password <br/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="old"></param>
        /// <param name="newP"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetPassword(User user, string old, string newP)
        {
            log.Debug("SetPassword() for : '" + user + "' from '" + old + "' to '" + newP);
            if (user == null)
            {
                log.Error("SetPassword() failed: '" + user + "' is null");
                throw new ArgumentNullException("User is null");
            }
            if (old == null)
            {
                log.Error("SetPassword() failed: '" + old + "' is null");
                throw new ArgumentNullException("Old password is null");
            }
            if (newP == null)
            {
                log.Error("SetPassword() failed: '" + newP + "' is null");
                throw new ArgumentNullException("New password is null");
            }
            if (userData.ContainsUser(user.GetEmail()) == false)
            {
                log.Error("SetPassword() failed: '" + user + "' is not in the system");
                throw new ArgumentException("User is not in the system");
            }
            if (!IsLegalPassword(newP))
            {
                log.Error("SetPassword() failed: '" + newP + "' is illegal");
                throw new ArgumentException("New password is illegal");
            }
            if (user.CheckPasswordMatch(old))
            {
                user.SetPassword(newP);
                log.Debug("SetPassword() success");
            }
            else
            {
                log.Error("SetPassword() failed: '" + old + "' incorrect");
                throw new ArgumentException("Old Password incorrect");
            }
        }

        /// <summary>
        /// Change the user's email <br/><br/>
        /// <b>Throws</b> <c>ArgumentNullException</c> if the user or new email entered are null <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user doesn't exist in the system <b>or</b> <br/> if a user with the new email exist in the system
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newE"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>

        public void SetEmail(User user, string newE)
        {
            log.Debug("SetEmail() for '" + user + "' to '" + newE);
            if (user == null)
            {
                log.Error("SetEmail() failed: '" + user + "' is null");
                throw new ArgumentNullException("User is null");
            }
            if (newE == null)
            {
                log.Error("SetEmail() failed: '" + newE + "' is null");
                throw new ArgumentNullException("New email is null");
            }
            if (userData.ContainsUser(user.GetEmail()) == false)
            {
                log.Error("SetEmail() failed: '" + user + "' doesn't exist");
                throw new ArgumentException("User dosen't exist");
            }
            if (userData.ContainsUser(newE) == true)
            {
                log.Error("SetEmail() failed: user with " + newE + " allready exist in the system");
                throw new ArgumentException("A user with that email already exists in the system");
            }
            user.SetEmail(newE);
            log.Debug("SetEmail() success");
        }

        /// <summary>
        ///Return user with the email entered <br/><br/>
        ///<b>Throws</b> <c>ArgumentNullException</c> if the email entered is null <br/>
        ///<b>Throws</b> <c>NoSuchElementException</c> if no user with that email exist in the system <br/>
        /// </summary> 
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NoSuchElementException"></exception>


        public User SearchUser(string email)
        {
            log.Debug("SearchUser() for: '" + email);
            if (email == null) 
            {
                log.Error("SearchUser() failed: '" + email + "' is null");
                throw new ArgumentNullException("Email is null"); 
            }
            try
            {
                User user = userData.SearchUser(email);
                log.Debug("SearchUser() success");
                return user;
            }
            catch (NoSuchElementException)
            {
                log.Error("SearchUser() failed: user with '" + email + "' doesn't exist in the system");
                throw new NoSuchElementException("User with '" + email + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Check the legality of a password <br/><br/>
        /// Returns: <br/>
        /// <b>True</b> if the password is legal and <b>False</b> otherwise
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        private static bool IsLegalPassword(string pass)
        {
            Regex smallLetters = new Regex(@"[a-z]");
            Regex capitalLetters = new Regex(@"[A-Z]");
            Regex numbers = new Regex(@"[0-9]");

            if (smallLetters.Matches(pass).Count > 0 &
                capitalLetters.Matches(pass).Count > 0 &
                numbers.Matches(pass).Count > 0 &
                pass.Length >= MIN_PASS_LENGTH &
                pass.Length <= MAX_PASS_LENGTH)
            {
                return true;
            }

            return false;
        }
    }
}

