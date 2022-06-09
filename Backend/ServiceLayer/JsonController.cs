using IntroSE.Kanban.Backend.BusinessLayer;
using System.Text.Json;
using System.Collections.Generic;

namespace IntroSE.Kanban.Backend.ServiceLayer 
{
	public static class JsonController
	{
		private readonly static JsonSerializerOptions options = new()
		{
			WriteIndented = true,
		};
		private static string Serialize<T>(T obj)
		{
			return JsonSerializer.Serialize(obj, options);
		}
		private static T Deserialize<T>(string json)
		{
			return JsonSerializer.Deserialize<T>(json, options);
		}


		//public functions

		public static string ConvertToJson(Task task)
		{
			return Serialize(task.GetSerializableInstance());
		}
		public static string ConvertToJson(Board board)
		{
			return Serialize(board.GetSerializableInstance());
		}
		public static string ConvertToJson(LinkedList<Board> boardList)
		{
			LinkedList<BusinessLayer.Serializable.Board_Serializable> boardList_Serializable = new();
			foreach (Board board in boardList) 
			{
				boardList_Serializable.AddLast(board.GetSerializableInstance());
			}
			return Serialize(boardList_Serializable);
		}
		public static string ConvertToJson(LinkedList<Task> taskList)
		{
			LinkedList<BusinessLayer.Serializable.Task_Serializable> taskList_Serializable = new();
			foreach (Task task in taskList)
			{
				taskList_Serializable.AddLast(task.GetSerializableInstance());
			}
			return Serialize(taskList_Serializable);
		}
		public static string ConvertToJson(User user)
		{
			return Serialize(user.GetSerializableInstance());
		}
		public static string ConvertToJson<T>(Response<T> response)
		{
			return Serialize(response);
		}
        public static string ConvertToJson<T>(GradingResponse<T> response)
        {
            return Serialize(response);
        }
        public static string ConvertToJson(intResponse response)
        {
            return Serialize(response);
        }
		public static T BuildFromJson<T>(string json)
		{
			return Deserialize<T>(json);
		}
	}
}

