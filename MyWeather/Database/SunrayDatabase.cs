using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Sunray.API;
using System.Threading.Tasks;

namespace Sunray
{
	// TODO: Async
	public class SunrayDatabase
	{
		static object locker = new object ();
		SQLiteAsyncConnection database;

		public SunrayDatabase ()
		{
			database = DependencyService.Get<ISQLite> ().GetAsyncConnection ();
			database.CreateTableAsync<Place>().ContinueWith (t => {
				Debug.WriteLine ("Place table created");
			});
		}

		public IEnumerable<Place> GetCities ()
		{
			lock (locker) {
				var places = new List<Place> ();
				var query = database.Table<Place>().ToListAsync().ContinueWith (t => {
					foreach (var place in t.Result)
					{
						places.Add(place);
					}
				});
				return places;
			}
		}

		public void AddPlace(Place placeToAdd)
		{
			lock (locker)
			{
				database.InsertOrReplaceAsync (placeToAdd).ContinueWith (t => {
					Debug.WriteLine ("Added place to db: {0}", placeToAdd.Name);
				});
			}
		}

		public void RemovePlace(Place placeToRemove)
		{
			lock (locker)
			{
				database.DeleteAsync (placeToRemove).ContinueWith (t => {
					Debug.WriteLine ("Removed place from db: {0}", placeToRemove.Name);
				});
			}
		}
	}
}

