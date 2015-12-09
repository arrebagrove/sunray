using System;
using SQLite;

namespace MyWeather
{
	public interface ISQLite
	{
		SQLiteAsyncConnection GetAsyncConnection();
	}
}

