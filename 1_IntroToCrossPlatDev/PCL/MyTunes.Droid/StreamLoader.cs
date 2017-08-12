using Android.Content;
using MyTunes.Shared;
using System.IO;

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