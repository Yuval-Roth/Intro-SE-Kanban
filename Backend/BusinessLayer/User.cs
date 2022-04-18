using System;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
	public class User : IComparable
	{
		private String email;
		private String password;
		public User()
		{
		}
		public void setPassword(String old, String newP)
		{
		}
		public void setEmail(String newE)
		{
		}
		public String getEmail()
		{
			return null;
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

