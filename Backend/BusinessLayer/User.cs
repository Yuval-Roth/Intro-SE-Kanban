using System;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
	public class User : IComparable
	{
		private string email;
		private string password;

		[JsonConstructor]
		public User(string email, string password)
		{
			this.email = email;
			this.password = password;
		}

		public void SetPassword(String old, String newP)
		{
			if (old != null && newP != null)
			{
				password = newP;
			}
		}
		public void SetEmail(String newE)
		{
			if (newE == null)  throw new ArgumentNullException("email is null");
			email = newE;
		}
		public String GetEmail()
		{
			return email;
		}
		public Boolean CheckPasswordMatch(String pass)
		{
			if (pass == null)  throw new ArgumentNullException("password is null"); 
			if (password.Equals(pass)) {
				return true;
			}
			return false;
		}
		public int CompareTo(object obj)
		{
			if (obj == null)  throw new ArgumentNullException("obj is null");
			if (obj is User)
			{
				return ((User)obj).email.CompareTo(this.email);
			}
			else
			{
				throw new ArgumentException("can't compare because obj is not User");
			}
		}
	}
}

