using Newtonsoft.Json;

namespace MyWeather.API
{
	[JsonObject]
	public class Forecast
	{
		public string Code { get; set; }
		public string Date { get; set; }
		public string Day { get; set; }
		public string High { get; set; }
		public string Low { get; set; }
		public string Text { get; set; }
	}
}

