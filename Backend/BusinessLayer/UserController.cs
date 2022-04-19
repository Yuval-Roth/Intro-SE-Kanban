using System;
using System.Collections.Generic;


namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class UserController
    {
        private BinaryTree<User> userList;
        private Dictionary<string, User> loggedIn;
        private static readonly int MIN_PASS_LENGTH = 8;
        private static readonly int MAX_PASS_LENGTH = 24;
        public UserController()
        {
            BinaryTree<User> userList = new BinaryTree<User>(); 
            Dictionary<string, User> loggedIn = new Dictionary<string, User>(); 
        }
        public void register(String email, String password)
        {
            if(email == null){ throw new ("ilegal email"); }
            if(password == null){ throw new ArgumentNullException("ilegal password"); }
            if (!legalPassword(password))
            {

            }
            if(userList.Contains)
        }
        public void deleteUser(User user)
        {
        }
        public void logIn(String email, String password)
        {
        }
        public void logOut()
        {
        }
        public void setPassword(User user, String old, String newP)
        {
        }
        public void setEmail(User user, String newE)
        {
        }
        public User searchUser(String email)
        {
            return null;
        }
        private Boolean legalPassword(String pass)
        {
            if (pass == null) { return false; }
            if (pass.Length < 6 | pass.Length > 20) { return false; }
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass.to)

        }
        }
}

