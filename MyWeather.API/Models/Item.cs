using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyWeather.API
{
	[JsonObject]
	public class Item
	{
		public Condition Condition { get; set; }
		public List<Forecast> Forecast { get; set; }
	}
}

