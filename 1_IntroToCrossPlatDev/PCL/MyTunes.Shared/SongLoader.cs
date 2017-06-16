using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using MyTunes.Shared;

namespace MyTunes
{
	public static class SongLoader
	{
		const string FILE_NAME = "songs.json";

        public static IStreamLoader Loader { get; set; }

		public static async Task<IEnumerable<Song>> Load()
		{
			using (var reader = new StreamReader(OpenData())) {
				return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
			}
		}

		private static Stream OpenData()
		{
            // open file
            if (Loader == null)
                throw new Exception("The IStreamLoader must be set before calling this function.");

            return Loader.GetStreamForFilename(FILE_NAME);
		}
	}
}

