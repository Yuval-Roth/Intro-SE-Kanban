using System;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
	public class User : IComparable
	{
		private string email;
		private string password;
		public User(string email, string password)
		{
			this.email = email;
			this.password = password;
		}
		public void setPassword(String old, String newP)
		{
		}
		public void setEmail(String newE)
		{
		}
		public String getEmail()
		{
			return email;
		}
		public Boolean checkPasswordMatch(String pass)
		{
			return false;
		}
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

