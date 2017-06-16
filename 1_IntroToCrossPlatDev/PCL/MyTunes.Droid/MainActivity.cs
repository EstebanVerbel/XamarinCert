﻿using System.Linq;
using Android.App;
using Android.OS;

namespace MyTunes
{
	[Activity(Label = "My Tunes", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            // set the loader property before calling load song
            SongLoader.Loader = new StreamLoader(this);

            var data = await SongLoader.Load();

			ListAdapter = new ListAdapter<Song>() {
				DataSource = data.ToList(),
				TextProc = s => s.Name,
				DetailTextProc = s => s.Artist + " - " + s.Album
			};
		}
	}
}


