using System;
using System.Text.Json;

namespace IntroSE.Kanban.Backend.ServiceLayer 
{
	public static class JsonController
	{
		public static string Generate(Response response)
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				WriteIndented = true,
				IncludeFields = true
			};
			return JsonSerializer.Serialize(response,options);
		}
	}
}

