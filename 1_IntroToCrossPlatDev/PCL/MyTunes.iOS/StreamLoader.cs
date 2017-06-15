using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MyTunes.Shared;
using System.IO;

namespace MyTunes
{
    public class StreamLoader : IStreamLoader
    {
        public Stream GetStreamForFilename(string fileName)
        {
            return File.OpenRead(fileName);
        }
    }
}