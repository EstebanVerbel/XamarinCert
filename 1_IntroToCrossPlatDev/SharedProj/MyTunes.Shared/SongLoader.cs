using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;

namespace MyTunes
{
	public static class SongLoader
	{
		const string FILE_NAME = "songs.json";

		public static async Task<IEnumerable<Song>> Load()
		{
			using (var reader = new StreamReader(OpenData())) {
				return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
			}
		}

        /// <summary>
        /// This Methos uses conditional compilation for each platform
        /// </summary>
        /// <returns></returns>
		private static Stream OpenData()
		{
            // TODO: add code to open file here.
#if __ANDROID__
            return Android.App.Application.Context.Assets.Open(FILE_NAME);
#elif __IOS__
            return File.OpenRead(FILE_NAME);
#else
            return null;
#endif
        }
        
	}
}

