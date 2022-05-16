using System;
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

		public static string ConvertToJson(BusinessLayer.Task task)
		{
			return Serialize(task.GetSerializableInstance());
		}
		public static string ConvertToJson(BusinessLayer.Board board)
		{
			return Serialize(board.GetSerializableInstance());
		}
		public static string ConvertToJson(LinkedList<BusinessLayer.Board> boardList)
		{
			LinkedList<BusinessLayer.Serializable.Board_Serializable> boardList_Serializable = new();
			foreach (BusinessLayer.Board board in boardList) 
			{
				boardList_Serializable.AddLast(board.GetSerializableInstance());
			}
			return Serialize(boardList_Serializable);
		}
		public static string ConvertToJson(BusinessLayer.User user)
		{
			return Serialize(user.GetSerializableInstance());
		}
		public static string ConvertToJson<T>(Response<T> response)
		{
			return Serialize(response);
		}
		public static string ConvertToJson<T>(GradingService.GradingResponse<T> response)
		{
			return Serialize(response);
		}
		public static T BuildFromJson<T>(string json)
		{
			return Deserialize<T>(json);
		}
	}
}

