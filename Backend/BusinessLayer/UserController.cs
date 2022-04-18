using System;
using System.Collections.Generic;


namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class UserController
    {
        private static readonly int MIN_PASS_LENGTH = 8;
        private static readonly int MAX_PASS_LENGTH = 24;
        public UserController()
        {
        }
        public void register(String email, String password)
        {
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
    }
}

