using Newtonsoft.Json;

namespace MyWeather.API
{
	[JsonObject]
	public class Wind
	{
		public string Direction { get; set; }
		public string Speed { get; set; }
	}
}

