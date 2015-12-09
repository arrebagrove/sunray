using System;
using SQLite;

namespace Sunray
{
	public interface ISQLite
	{
		SQLiteAsyncConnection GetAsyncConnection();
	}
}

