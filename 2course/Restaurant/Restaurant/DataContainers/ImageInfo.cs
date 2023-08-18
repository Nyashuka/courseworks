using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class ImageInfo
    {
        public string PathToPicture { get; private set; }

        public ImageInfo(string pathToFile) 
        {
            PathToPicture = pathToFile;
        }
    }
}
