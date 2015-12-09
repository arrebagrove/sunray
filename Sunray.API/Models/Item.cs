using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sunray.API
{
	[JsonObject]
	public class Item
	{
		public Condition Condition { get; set; }
		public List<Forecast> Forecast { get; set; }
	}
}

