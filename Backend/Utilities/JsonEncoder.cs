
using System.Text.Json;


namespace IntroSE.Kanban.Backend.ServiceLayer 
{
	public static class JsonEncoder
	{
        private readonly static JsonSerializerOptions options = new()
		{
			WriteIndented = true,
		};
		public static string ConvertToJson<T>(T obj)
		{
			return JsonSerializer.Serialize(obj, options);
		}
		public static T BuildFromJson<T>(string json)
		{
			return JsonSerializer.Deserialize<T>(json, options);
		}
	}
}

