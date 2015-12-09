using Newtonsoft.Json;

namespace Sunray.API
{
	[JsonObject ("channel")]
	public class Channel
	{
		public Location Location { get; set; }
		public Units Units { get; set; }
		public Wind Wind { get; set; }
		public Atmosphere Atmosphere { get; set; }
		public Item Item { get; set; }
	}
}

