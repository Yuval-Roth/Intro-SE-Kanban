using System;
using System.Text.Json;

namespace IntroSE.Kanban.Backend.ServiceLayer 
{
	public static class JsonController
	{
		private readonly static JsonSerializerOptions options = new()
		{
			WriteIndented = true,
		};
		public static string Serialize<T>(T obj)
		{
			return JsonSerializer.Serialize<T>(obj, options);
		}
		public static T Deserialize<T>(string json)
		{
			return JsonSerializer.Deserialize<T>(json, options);
		}
	}
}

