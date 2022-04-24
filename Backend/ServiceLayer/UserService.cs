using System;
namespace IntroSE.Kanban.Backend.ServiceLayer
{
	public class UserService
	{
		BusinessLayer.UserController userController;

		public UserService()
		{
			userController = new BusinessLayer.UserController();
		}
		public string Register(String email, String password)
		{
			try
			{
				userController.Register(email, password);
				Response res = new Response(true, "Registration completed");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string DeleteUser(BusinessLayer.User user)
		{
            try
            {
				BusinessLayer.User toDelete = userController.SearchUser(email);
				userController.DeleteUser(toDelete);
				Response res = new Response(true, "Deleted successesfully");
				return JsonController.ConvertToJson(res);
			}
            catch (ArgumentNullException ex)
            {
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
            {
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string LogIn(String email, String password)
		{
            try
            {
				userController.LogIn(email, password);
				Response res = new Response(true, "LoggedIn successesfully");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
            {
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
            {
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string LogOut(BusinessLayer.User user)
		{
            try
            {
				BusinessLayer.User toLogOut = userController.SearchUser(email);
				userController.LogOut(toLogOut);
				Response res = new Response(true, "LoggedOut successesfully");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
            {
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string SetPassword(BusinessLayer.User user, String old, String newp)
		{
            try
            {
				BusinessLayer.User toSetPassword = userController.SearchUser(email);
				userController.SetPassword(toSetPassword, old, newp);
				Response res = new Response(true, "Password changed successesfully");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string SetEmail(BusinessLayer.User user, String newe)
		{
            try
            {
				BusinessLayer.User toSetEmail = userController.SearchUser(email);
				userController.SetEmail(toSetEmail, newEmail);
				Response res = new Response(true, "Email changed successesfully");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response res = new Response(false, ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
	}
}

