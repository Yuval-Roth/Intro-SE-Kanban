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
        public void Register(String email, String password)
        {
            if(email == null){ throw new ArgumentException ("ilegal email"); }
            if(password == null){ throw new ArgumentException ("ilegal password"); }
            if (!IsLegalPassword(password)) { throw new ArgumentException("Password ilegal"); }
            User newUser = new User(email, password);
            if (userList.Contains(newUser))
            {
                throw new ArgumentException("A user with that email already exists in the system");
            }
            userList.Add(newUser);
        }
        public void DeleteUser(User user)
        {
            if(user == null)  throw new ArgumentNullException("input is null"); 
            if (userList.Contains(user))
            {
                userList.Remove(user);
            }
            else
            {
                throw new ArgumentException("there is no such user in the system");
            }
        }
        public void LogIn(String email, String password)
        {
            if(password == null)  throw new ArgumentNullException ("password is null"); 
            if(email == null) throw new ArgumentNullException ("email is null"); 
            User newUser=new User(email, password);
            if (userList.Contains(newUser))
            {
                if (newUser.CheckPasswordMatch(password))
                {
                    loggedIn.Add(email, newUser);
                }
                else
                {
                    throw new ArgumentException("wrong password");
                }
            }
            else
            {
                throw new ArgumentException("there is no such user in the system");  
            }
        }

        public void LogOut(User user)
        {
            if (user == null)  throw new ArgumentNullException("user is null"); 
            if (!loggedIn.ContainsValue(user))  throw new ArgumentException("user not loggedIn"); 
            loggedIn.Remove(user.GetEmail());
        }
        public void SetPassword(User user, String old, String newP)
        {
            if(user == null)  throw new ArgumentNullException("user is null");
            if (old == null)  throw new ArgumentNullException("old password is null"); 
            if (newP == null)  throw new ArgumentNullException("new password is null"); 
            if(!userList.Contains(user))  throw new ArgumentException("user is not in the system"); 
            if (!IsLegalPassword(newP))  throw new ArgumentException("new password is illegal"); 
            if (user.CheckPasswordMatch(old))
            {
                user.SetPassword(old, newP);    
            }
            else
            {
                throw new ArgumentException("password incorrect");
            }
            

        }

        public void SetEmail(User user, String newE)
        {
            if (!userList.Contains(user))  throw new ArgumentException("user dosen't exist"); 
            User newUser = new User(newE, "");
            if (userList.Contains(newUser))  throw new ArgumentException("A user with that email already exists in the system");
            user.SetEmail(newE);
        }

        public User SearchUser(String email)
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
        private bool IsLegalPassword(string pass)
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


            //if (pass == null) { return false; }
            //if (pass.Length < MIN_PASS_LENGTH | pass.Length > MAX_PASS_LENGTH) { return false; }
            //String SmallLet = @"\b[a-z]{1,}";
            //String BigLet = @"\b[A-Z]{1,}";
            //String num = @"\b[0-9]{1,}";
            //Regex rg = new Regex(@SmallLet); 
            //MatchCollection matchedAuthors = rg.Matches(pass);
            //for (int i = 0; i < matchedAuthors.Count; i++)
            //{
            //    if (matchedAuthors[i].Equals(pass))
            //    {
            //        Regex rg2 = new Regex(BigLet);
            //        MatchCollection matchedAuthors2 = rg2.Matches(pass);
            //        for(int j = 0; j < matchedAuthors2.Count; j++)
            //        {
            //            if (matchedAuthors2[j].Equals(pass))
            //            {
            //                Regex rg3 = new Regex(num);
            //                MatchCollection matchedAuthors3 = rg3.Matches(pass);
            //                for(int k = 0; k < matchedAuthors3.Count; k++)
            //                {
            //                    if (matchedAuthors3[k].Equals(pass))
            //                    {
            //                        return true;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //return false;
        }
    }
}

