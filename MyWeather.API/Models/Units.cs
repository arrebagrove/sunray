using Newtonsoft.Json;

namespace MyWeather.API
{
	[JsonObject]
	public class Units
	{
		public string Distance { get; set; }
		public string Pressure { get; set; }
		public string Speed { get; set; }
		public string Temperature { get; set; }
	}
}

