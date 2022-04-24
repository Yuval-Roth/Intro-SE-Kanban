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
		public string Register(string email, string password)
		{
			try
			{
				userController.Register(email, password);
				Response res = new Response("{}");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string DeleteUser(string email)
		{
            try
            {
				BusinessLayer.User toDelete = userController.SearchUser(email);
				userController.DeleteUser(toDelete);
				Response res = new Response("{}");
				return JsonController.ConvertToJson(res);
			}
            catch (ArgumentNullException ex)
            {
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
            {
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string LogIn(string email, string password)
		{
            try
            {
				userController.LogIn(email, password);
				Response res = new Response("{}");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
            {
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
            {
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string LogOut(string email)
		{
            try
            {
				BusinessLayer.User toLogOut = userController.SearchUser(email);
				userController.LogOut(toLogOut);
				Response res = new Response("{}");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
            {
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string SetPassword(string email, string old, string newp)
		{
            try
            {
				BusinessLayer.User toSetPassword = userController.SearchUser(email);
				userController.SetPassword(toSetPassword, old, newp);
				Response res = new Response("{}");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
		public string SetEmail(string email, string newEmail)
		{
            try
            {
				BusinessLayer.User toSetEmail = userController.SearchUser(email);
				userController.SetEmail(toSetEmail, newEmail);
				Response res = new Response("{}");
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentNullException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (BusinessLayer.NoSuchElementException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
			catch (ArgumentException ex)
			{
				Response res = new Response(ex.Message);
				return JsonController.ConvertToJson(res);
			}
		}
	}
}

