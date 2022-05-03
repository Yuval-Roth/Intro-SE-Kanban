using System;
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

		public UserService(BusinessLayer.UserData userData)
		{
			userController = new BusinessLayer.UserController(userData);
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
			try
			{
				userController.Register(email, password);
				Response<string> res = new(true,"");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response<string> res = new(false,ex.Message);
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
            try
            {
				BusinessLayer.User toDelete = userController.SearchUser(email);
				userController.DeleteUser(toDelete);
				Response<string> res = new(true,"");
				return JsonController.ConvertToJson(res);
			}
            catch (ArgumentNullException ex)
            {
				Response<string> res = new(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
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
            try
            {
				userController.LogIn(email, password);
				Response<string> res = new(true, "");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
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
            try
            {
				BusinessLayer.User toLogOut = userController.SearchUser(email);
				userController.LogOut(toLogOut);
				Response<string> res = new(true, "");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
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
            try
            {
				BusinessLayer.User toSetPassword = userController.SearchUser(email);
				userController.SetPassword(toSetPassword, old, newP);
				Response<string> res = new(true, "");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
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
            try
            {
				BusinessLayer.User toSetEmail = userController.SearchUser(email);
				userController.SetEmail(toSetEmail, newEmail);
				Response<string> res = new(true, "{}");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response<string> res = new(false,ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
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

