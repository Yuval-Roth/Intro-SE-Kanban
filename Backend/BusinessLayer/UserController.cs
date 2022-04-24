using System;
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
        private BinaryTree<User> userList;
        private readonly Dictionary<string, User> loggedIn;
        private static readonly int MIN_PASS_LENGTH = 6;
        private static readonly int MAX_PASS_LENGTH = 20;

        /// <summary>
        /// Creates an empty <c>BinaryTree</c> userList <br/>
        /// Creates an empty <c>Dictionary</c> loggedIn
        /// </summary>
        public UserController()
        {
            userList = new BinaryTree<User>(); 
            loggedIn = new Dictionary<string, User>(); 
        }

        /// <summary>
        /// Add new <c>User</c> to <c>BinaryTree</c> userList <br/> <br/>
        /// <b>Throws</b> <c>ArgumentNullException</c> if email or password entered are null <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user allready exists or if the password entered is illegal
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>

        public void Register(String email, String password)
        {
            if(email == null){ throw new ArgumentNullException ("ilegal email"); }
            if(password == null){ throw new ArgumentNullException("ilegal password"); }
            if (!IsLegalPassword(password)) { throw new ArgumentException("Password ilegal"); }
            User newUser = new User(email, password);
            try
            {
                userList.Add(newUser);
            }
            catch (ArgumentException)
            {
                throw;
            }
            
        }

        /// <summary>
        ///Delate <c>User</c> from the <c>BinaryTree</c> userList <br/> <br/>
        ///<b>Throws</b> <c>ArgumentNullException</c> if the user entered is null <br/>
        ///<b>Throws</b> <c>NoSuchElementException</c> if the user doesn't exist in the userList
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void DeleteUser(User user)
        {
            if(user == null)  throw new ArgumentNullException("input is null");
            try
            {
                userList.Remove(user);
            }
            catch (NoSuchElementException)
            {
                throw;
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
            if(password == null)  throw new ArgumentNullException ("password is null"); 
            if(email == null) throw new ArgumentNullException ("email is null"); 
            User newUser=new User(email, password);
            if (userList.Contains(newUser))
            {
                if (newUser.CheckPasswordMatch(password))
                {
                    try
                    {
                        loggedIn.Add(email, newUser);
                    }
                    catch(ArgumentException)
                    {
                        throw;
                    }
                    
                }
            }
            else
            {
                throw new ArgumentException("there is no such user in the system");  
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
            if (user == null)  throw new ArgumentNullException("user is null"); 
            if (!loggedIn.ContainsValue(user))  throw new ArgumentException("user not loggedIn");
            try
            {
                loggedIn.Remove(user.GetEmail());
            }
            catch (ArgumentNullException)
            {
                throw;
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
            if(user == null)  throw new ArgumentNullException("user is null");
            if (old == null)  throw new ArgumentNullException("old password is null"); 
            if (newP == null)  throw new ArgumentNullException("new password is null"); 
            if(!userList.Contains(user))  throw new ArgumentException("user is not in the system"); 
            if (!IsLegalPassword(newP))  throw new ArgumentException("new password is illegal"); 
            if (user.CheckPasswordMatch(old))
            {
                user.SetPassword(newP);    
            }
            else
            {
                throw new ArgumentException("password incorrect");
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
            if (user == null) throw new ArgumentNullException("user is null");
            if (newE == null) throw new ArgumentNullException("new email is null"); 
            if (!userList.Contains(user))  throw new ArgumentException("user dosen't exist"); 
            User newUser = new User(newE, "");
            if (userList.Contains(newUser))  throw new ArgumentException("A user with that email already exists in the system");
            user.SetEmail(newE);
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
            if (email == null) { throw new ArgumentNullException("email is null"); }
            User newUser = new User(email, "");
            try
            {
                return userList.Search(newUser).GetElement();
            }
            catch (NoSuchElementException)
            {
                throw;
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

