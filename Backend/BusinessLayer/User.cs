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
			if (old != null && newP != null)
            {
				password = newP;
            }
		}
		public void setEmail(String newE)
		{
			if (newE == null) {  throw new ArgumentNullException("")}
			email = newE;
		}
		public String getEmail()
		{
			return email;
		}
		public Boolean checkPasswordMatch(String pass)
		{
			if(pass == null) { throw new ArgumentNullException()}
            if (password.Equals(pass)) {
				return true;
			}
			return false;
		}
        public int CompareTo(object obj)
        {
			if(obj == null) { throw new ArgumentNullException()}
			if(obj is User) {
				return ((User)obj).email.CompareTo(((User)obj).email);
        }
			return 0;
    }
}

