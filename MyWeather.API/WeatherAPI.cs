using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyWeather.API
{		
	[JsonObject]
	public class Condition
	{
		public string Code { get; set; }
		public string date { get; set; }
		public string temp { get; set; }
		public string text { get; set; }
	}

	[JsonObject]
	public class Forecast
	{
		public string code { get; set; }
		public string date { get; set; }
		public string day { get; set; }
		public string high { get; set; }
		public string low { get; set; }
		public string text { get; set; }
	}

	[JsonObject]
	public class Atmosphere
	{
		public string humidity { get; set; }
		public string pressure { get; set; }
		public string rising { get; set; }
		public string visibility { get; set; }
	}

	[JsonObject]
	public class Units
	{
		public string distance { get; set; }
		public string pressure { get; set; }
		public string speed { get; set; }
		public string temperature { get; set; }
	}

	[JsonObject]
	public class Wind
	{
		public string direction { get; set; }
		public string speed { get; set; }
	}

	[JsonObject]
	public class Location
	{
		public string city { get; set; }
		public string country { get; set; }
	}

	[JsonObject]
	public class Item
	{
		public string title { get; set; }
		public string lat { get; set; }
		public string @long { get; set; }
		public string link { get; set; }
		public string pubDate { get; set; }
		public Condition condition { get; set; }
		public string description { get; set; }
		public List<Forecast> forecast { get; set; }
	}

	[JsonObject]
	public class Channel
	{
		public string title { get; set; }
		public string link { get; set; }
		public string description { get; set; }
		public Location location { get; set; }
		public Units units { get; set; }
		public Wind wind { get; set; }
		public Atmosphere atmosphere { get; set; }
		public Item item { get; set; }
	}

	[JsonObject]
	public class Results
	{
		public Channel channel { get; set; }
	}

	[JsonObject]
	public class Query
	{
		public Results results { get; set; }
	}

	[JsonObject]
	public class RootObject
	{
		public Query query { get; set; }
	}
}