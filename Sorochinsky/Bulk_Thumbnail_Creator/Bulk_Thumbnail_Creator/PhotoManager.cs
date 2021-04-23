using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bulk_Thumbnail_Creator
{
    public class PhotoManager
    {
        public void RenameImages(FileInfo[] files, string newFilesName, CancellationToken token, out bool isCanceled)
        {
            int fileNumber = 1;

            foreach (var item in files)
            {
                if (token.IsCancellationRequested)
                {
                    isCanceled = true;
                    return;
                }

                item.MoveTo(Path.Combine(item.Directory.FullName, $"{newFilesName}{fileNumber}.jpg"));
                fileNumber++;
            }
        }

        public void ResizeImages(string filePath, string newFilePath, int width, int heigth, CancellationToken token, out bool isCanceled)
        {
            int fileIndex = 1;
            string[] files = Directory.GetFiles(filePath);

            foreach (var item in files)
            {
                if (token.IsCancellationRequested)
                {
                    isCanceled = true;
                    return;
                }

                Bitmap bmp = new Bitmap(item);
                Bitmap image = new Bitmap(bmp, width, heigth);
                image.Save($"{newFilePath}/{fileIndex}.jpg");
                fileIndex++;
            }
        }
    }
}
