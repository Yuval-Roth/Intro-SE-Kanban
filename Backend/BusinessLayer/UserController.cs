using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;


namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class UserController
    {
        private BinaryTree<User> userList;
        private Dictionary<string, User> loggedIn;
        private static readonly int MIN_PASS_LENGTH = 6;
        private static readonly int MAX_PASS_LENGTH = 20;
        public UserController()
        {
            BinaryTree<User> userList = new BinaryTree<User>(); 
            Dictionary<string, User> loggedIn = new Dictionary<string, User>(); 
        }
        public void register(String email, String password)
        {
            if(email == null){ throw new ArgumentException ("ilegal email"); }
            if(password == null){ throw new ArgumentException ("ilegal password"); }
            if (!ligalPassword(password)) { throw new ArgumentException("Password ilegal"); }
            User newUser = new User(email, password);
            if (userList.Contains(newUser))
            {
                throw new ArgumentException("email allready excist in the system");
            }
            userList.Add(newUser);
        }
        public void deleteUser(User user)
        {
            if(user == null) { throw new ArgumentNullException ("input is null")}
            if (userList.Contains(user))
            {
                userList.Remove(user);
            }
        }
        public void logIn(String email, String password)
        {
            if(password == null) { throw new ArgumentNullException ("password is null"); }
            if(email == null){ throw new ArgumentNullException ("email is null"); }
            User newUser=new User(email, password);
            if (userList.Contains(newUser))
            {
                loggedIn.Add(email, newUser);
            }
            else
            {
                throw new ArgumentException("there is no such user in the system");
            }
        }
        public void logOut(User user)
        {
            if (user == null) { throw new ArgumentNullException ("user is null")}
            if (!loggedIn.ContainsValue(user)) { throw new ArgumentException("user not loggedIn") }
            loggedIn.Remove(user.getEmail());
        }
        public void setPassword(User user, String old, String newP)
        {
            if(user == null) { throw new ArgumentNullException("user is null")};
            if (old == null) { throw new ArgumentNullException("old password is null")};
            if (newP == null) { throw new ArgumentNullException("new password is null")};
            if(!userList.Contains(user)) { throw new ArgumentException("user is not in the system")};
            if (!isLigalPassword(newP)) { throw new ArgumentException("new password is ilegal")};
            if (user.checkPasswordMatch(old))
            {
                user.setPassword(old, newP);    
            }
            throw new ArgumentException("password incorrect");

        }

        public void setEmail(User user, String newE)
        {
            if (!userList.Contains(user)) { throw new ArgumentException("user isn't excist"); }
            User newUser = new User(newE, "");
            if (userList.Contains(newUser)) { throw new ArgumentException("email allready excist in the system")};
            user.setEmail(newE);
        }

        public User searchUser(String email)
        {
            if (email == null) { throw new ArgumentNullException("email is null")};
            User newUser = new User(email, "");
            try
            {
                User user = userList.Search(newUser).GetElement();
                return user;
            }
            catch (NoSuchElementException)
            {
                throw;
            }
        }
        private Boolean isLigalPassword(String pass)
        {
            if (pass == null) { return false; }
            if (pass.Length < 6 | pass.Length > 20) { return false; }
            Regex rx = new Regex(@"\^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,20}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            

        }
        }
}

