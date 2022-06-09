using System;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

	/// <summary>
	///This class implements the object <c>User</c>
	///<br/>
	///<code>Supported operations:</code>
	///<br/>
	/// <list type="bullet">SetPassword()</list>
	/// <list type="bullet">SetEmail()</list>
	/// <list type="bullet">GetEmail()</list>
	/// <list type="bullet">CheckPasswordMatch()</list>
	/// <br/><br/>
	/// ===================
	/// <br/>
	/// <c>Ⓒ Hadas Printz</c>
	/// <br/>
	/// ===================
	/// </summary>
	public class User
    {
		private string email;
		private string password;

		/// <summary>
		/// Initialize email and password fields
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		[JsonConstructor]
		public User(string email, string password)
		{
			this.email = email;
			this.password = password;
		}

		public User(DataAccessLayer.UserDTO userDTO)
		{
			email = userDTO.Email;
			password = userDTO.Password;
		}

		public string Email => email;

		/// <summary>
		/// Replace the user's password with the new password entered
		/// </summary>
		/// <param name="newP"></param>
		public void SetPassword(string newP)
		{
			if (newP != null)
			{
				password = newP;
			}
		}

		/// <summary>
		/// Change the user's email to the new email entered
		/// </summary>
		/// <param name="newE"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public void SetEmail(string newE)
		{
			if (newE == null)  throw new ArgumentNullException("email is null");
			email = newE;
		}

		/// <summary>
		/// Returns user's email
		/// </summary>
		/// <returns></returns>
		public string GetEmail()
		{
			return email;
		}

		

		/// <summary>
		/// Check if the user's password match the password entered <br/><br/>
		/// <b>Throws</b> <n>ArgumentNullException</n> if the password entered is null <br/><br/>
		/// Returns: <b>True</b> if the password match and <b>False</b> otherWise
		/// </summary>
		/// <param name="pass"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public bool CheckPasswordMatch(string pass)
		{
			if (pass == null)  throw new ArgumentNullException("password is null"); 
			if (password.Equals(pass)) {
				return true;
			}
			return false;
		}


		///// <summary>
		///// Compare this instance with the entered object and indicates whether this instance is bigger, smaller or same as the object <br/><br/>
		/////<b>Throws</b> <c>ArgumentNullException</c> if the object entered is null <br/>
		/////<b>Throws</b> <c>ArgumentException</c> if the object isn't instance of User <br/>
		///// </summary>
		///// <param name="obj"></param>
		///// <returns></returns>
		///// <exception cref="ArgumentNullException"></exception>
		///// <exception cref="ArgumentException"></exception>
		//public int CompareTo(object obj)
		//{
		//	if (obj == null) throw new ArgumentNullException("obj is null");
		//	if (obj is User)
		//	{
		//		return ((User)obj).email.CompareTo(this.email);
		//	}
		//	else
		//	{
		//		throw new ArgumentException("can't compare because obj is not User");
		//	}
		//}
			//====================================================
			//                  Json related
			//====================================================

			public Serializable.User_Serializable GetSerializableInstance()
			{
				return new Serializable.User_Serializable
				{
					Email = email,
					Password = "CENSORED"
				};
			}
		
	}
}

