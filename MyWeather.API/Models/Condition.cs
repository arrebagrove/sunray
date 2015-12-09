using Newtonsoft.Json;

namespace Sunray.API
{
	[JsonObject]
	public class Condition
	{
		public string Code { get; set; }
		public string Date { get; set; }
		public string Temp { get; set; }
		public string Text { get; set; }
	}
}

