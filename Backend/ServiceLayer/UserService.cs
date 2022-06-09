using System;
using IntroSE.Kanban.Backend.BusinessLayer;

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
		BusinessLayer.UserController userController;

		/// <summary>
		/// Initialize userController
		/// </summary>
		/// <param name="userData"></param>

		public UserService(BusinessLayer.UserController UC)
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
		public string Register(string email, string password)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { email,password }) == false)
			{
				Response<string> res = new(false, "Register() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			try
			{
				userController.Register(email.ToLower(), password);
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
		public string DeleteUser(string email)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { email }) == false)
			{
				Response<string> res = new(false, "DeleteUser() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			try
            {
				userController.DeleteUser(email.ToLower());
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
		public string LogIn(string email, string password)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { email, password }) == false)
			{
				Response<string> res = new(false, "LogIn() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			try
            {
				userController.LogIn(email.ToLower(), password);
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
		public string LogOut(string email)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { email }) == false)
			{
				Response<string> res = new(false, "LogOut() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			try
            {
				userController.LogOut(email.ToLower());
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
		public string SetPassword(string email, string old, string newP)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { email, old,newP }) == false)
			{
				Response<string> res = new(false, "SetPassword() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			try
            {
				User toSetPassword = userController.SearchUser(email.ToLower());
				userController.SetPassword(toSetPassword, old, newP);
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
		public string SetEmail(string email, string newEmail)
		{
			if (ValidateArguments.ValidateNotNull(new object[] { email, newEmail}) == false)
			{
				Response<string> res = new(false, "SetEmail() failed: ArgumentNullException");
				return JsonController.ConvertToJson(res);
			}
			try
            {
				User toSetEmail = userController.SearchUser(email.ToLower());
				userController.SetEmail(toSetEmail, newEmail.ToLower());
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

