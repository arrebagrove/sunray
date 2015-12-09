using Newtonsoft.Json;

namespace Sunray.API
{
	[JsonObject]
	public class Wind
	{
		public string Direction { get; set; }
		public string Speed { get; set; }
	}
}

