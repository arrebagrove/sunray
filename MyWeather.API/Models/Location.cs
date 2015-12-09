using System;
using Newtonsoft.Json;

namespace Sunray.API
{
	[JsonObject]
	public class Location
	{
		public string City { get; set; }
		public string Region { get; set; }
		public string Country { get; set; }
	}
}

