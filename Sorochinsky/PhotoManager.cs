using System.Drawing;
using System.IO;
using System.Threading;

namespace Bulk_Thumbnail_Creator
{
    public class PhotoManager
    {
        public static void RenameImages(FileInfo[] files,  string newFilesName, CancellationToken token, out bool isCanceled)
        {
            int fileNumber = 1;
            isCanceled = false;

            foreach (var item in files)
            {
                if (token.IsCancellationRequested)
                {
                    isCanceled = true;
                    return;
                }

                item.MoveTo(Path.Combine(item.Directory.FullName, $"{newFilesName}{fileNumber}.jpg"));
                fileNumber++;

                Thread.Sleep(1000);
            }
        }

        public static void ResizeImages(string filePath, int width, int heigth, CancellationToken token, out bool isCanceled)
        {
            int fileIndex = 1;
            string[] files = Directory.GetFiles(filePath);

            isCanceled = false;

            foreach (var item in files)
            {
                if (token.IsCancellationRequested)
                {
                    isCanceled = true;
                    return;
                }

                Bitmap bmp = new Bitmap(item);
                Bitmap image = new Bitmap(bmp, width, heigth);
                image.Save($"{filePath}/{fileIndex}.jpg");
                fileIndex++;

                Thread.Sleep(1000);
            }
        }
    }
}