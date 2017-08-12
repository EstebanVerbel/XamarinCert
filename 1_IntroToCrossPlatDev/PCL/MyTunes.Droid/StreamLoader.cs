using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyTunes.Shared;

namespace MyTunes
{
    public class StreamLoader : IStreamLoader
    {
        private readonly Context _context;
        
        public StreamLoader(Context context)
        {
            // Android assets are loaded through an Android Context so pass in a Context to the constructor
            _context = context;
        }
        
        public Stream GetStreamForFilename(string fileName)
        {
            return _context.Assets.Open(fileName);
        }
    }
}