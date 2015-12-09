using System;
using Xamarin.Forms;
using System.IO;
using Sunray;
using Sunray.iOS;
using SQLite;

[assembly: Dependency (typeof (SQLite_iOS))]

namespace Sunray.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS ()
		{
		}

		#region ISQLite implementation

		public SQLiteAsyncConnection GetAsyncConnection ()
		{
			var sqliteFilename = "SunraySQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

			// This is where we copy in the prepopulated database
			Console.WriteLine (path);
			if (!File.Exists (path)) {
				File.Copy (sqliteFilename, path);
			}

			var conn = new SQLite.SQLiteAsyncConnection(path);

			// Return the database connection 
			return conn;
		}

		#endregion
	}
}
