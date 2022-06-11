using System;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.Utilities;
using IntroSE.Kanban.Backend.Exceptions;

namespace IntroSE.Kanban.Backend.ServiceLayer
{

	/// <summary>
	///This class implements UserService 
	///<br/>
	///<code>Supported operations:</code>
	///<br/>
	/// <list type="bullet">Register()</list>
	/// <list type="bullet">DeleteUser()</list>
	/// <list type="bullet">LogIn()</list>
	/// <list type="bullet">LogOut()</list>
	/// <list type="bullet">SetPassword()</list>
	/// <list type="bullet">SetEmail()</list>
	/// <br/><br/>
	/// ===================
	/// <br/>
	/// <c>Ⓒ Hadas Printz</c>
	/// <br/>
	/// ===================
	/// </summary>
	
	public class UserService
	{
		UserController userController;

		/// <summary>
		/// Initialize userController
		/// </summary>
		/// <param name="userData"></param>

		public UserService(UserController UC)
		{
			userController = UC;
		}

		/// <summary>
		/// Register user with the email and password entered <br/><br/>
		/// </summary>
		/// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: string // (operationState == true) => empty string
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
		public string Register(string emailRaw, string password)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { emailRaw,password }) == false)
			{
				Response<string> res = new(false, "Register() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			CIString email = new CIString(emailRaw);
			try
			{
				userController.Register(email, password);
				Response<string> res = new(true,"");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response<string> res = new(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}

		/// <summary>
		/// Delete user with the email entered <br/><br/>
		/// </summary>
		/// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: string // (operationState == true) => empty string
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
		public string DeleteUser(string emailRaw)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { emailRaw }) == false)
			{
				Response<string> res = new(false, "DeleteUser() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			CIString email = new CIString(emailRaw);
			try
            {
				userController.DeleteUser(email);
				Response<string> res = new(true,"");
				return JsonController.ConvertToJson(res);
			}
			catch (UserDoesNotExistException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
            {
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}

		/// <summary>
		/// LogIn user with the email and password entered <br/><br/>
		/// </summary>
		/// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: string // (operationState == true) => empty string
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
		public string LogIn(string emailRaw, string password)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { emailRaw, password }) == false)
			{
				Response<string> res = new(false, "LogIn() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			CIString email = new CIString(emailRaw);
			try
            {
				userController.LogIn(email, password);
				Response<string> res = new(true, "");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
            {
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}

		/// <summary>
		/// LogOut user with the email entered <br/><br/>
		/// </summary>
		/// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: string // (operationState == true) => empty string
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
		public string LogOut(string emailRaw)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { emailRaw }) == false)
			{
				Response<string> res = new(false, "LogOut() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			CIString email = new CIString(emailRaw);
			try
            {
				userController.LogOut(email);
				Response<string> res = new(true, "");
				return JsonController.ConvertToJson(res);
			}
			catch (NoSuchElementException ex)
            {
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}

		/// <summary>
		/// SetPassword to newP of user with the email and password entered <br/><br/>
		/// </summary>
		/// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: string // (operationState == true) => empty string
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
		public string SetPassword(string emailRaw, string old, string newP)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { emailRaw, old,newP }) == false)
			{
				Response<string> res = new(false, "SetPassword() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			CIString email = new CIString(emailRaw);
			try
            {
				User toSetPassword = userController.SearchUser(email);
				userController.SetPassword(emailRaw, old, newP);
				Response<string> res = new(true, "");
				return JsonController.ConvertToJson(res);
			}
			catch (UserDoesNotExistException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}

		/// <summary>
		/// Set email to newEmail of user with the email entered <br/><br/>
		/// </summary>
		/// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: string // (operationState == true) => empty string
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
		public string SetEmail(string emailRaw, string newEmailRaw)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { emailRaw, newEmailRaw}) == false)
			{
				Response<string> res = new(false, "SetEmail() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			CIString email = new CIString(emailRaw);
			CIString newEmail = new CIString(newEmailRaw);
			try
            {
				User toSetEmail = userController.SearchUser(email);
				userController.SetEmail(emailRaw, newEmail);
				Response<string> res = new(true, "");
				return JsonController.ConvertToJson(res);
			}
			catch (UserDoesNotExistException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
	}
}

