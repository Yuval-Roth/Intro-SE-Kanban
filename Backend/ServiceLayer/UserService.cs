using System;
namespace IntroSE.Kanban.Backend.ServiceLayer
{
	public class UserService
	{

		public UserService()
		{
		}
		public string Register(String email, String password)
		{
			return "";
		}
		public string DeleteUser(BusinessLayer.User user)
		{
			return "";
		}
		public string LogIn(String email, String password)
		{
			return "";
		}
		public string LogOut(BusinessLayer.User user)
		{
			return "";
		}
		public string SetPassword(BusinessLayer.User user, String old, String newp)
		{
			return "";
		}
		public string SetEmail(BusinessLayer.User user, String newe)
		{
			return "";
		}
		public static string UserToJson(BusinessLayer.User user)
		{
			BusinessLayer.Serializable.User_Serializable toSerialize = new ()
			{
				Email = user.GetEmail(),
				Password = "CENSORED"
			};
			return ServiceLayer.JsonController.Serialize(toSerialize);
		}
		public static BusinessLayer.User BuildUserFromJson(string json)
		{
			return ServiceLayer.JsonController.Deserialize<BusinessLayer.User>(json);
		}
	}
}

