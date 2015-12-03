using System;
using Newtonsoft.Json;

namespace MyWeather.API
{
	[JsonObject]
	public class Atmosphere
	{
		public string Humidity { get; set; }
	}
}

