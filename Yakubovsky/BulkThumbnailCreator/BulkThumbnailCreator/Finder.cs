using System.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace BulkThumbnailCreator
{
    public class Finder
    {
        public const string oldFilePath = "/Users/tim143/Desktop/pathStart"; // Full path of old file
        public const string newFilePath = "/Users/tim143/Desktop/pathEnd"; // Full path of new file
        
        public void RenameImages(CancellationToken token)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(oldFilePath);
            FileInfo[] files = directoryInfo.GetFiles();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter new name for all files: ");
            string newNameForAllFilesInFolder = Console.ReadLine();
            Console.ResetColor();
            
            int index = 1;
            foreach (var item in files)
            {
                item.Rename($"{newNameForAllFilesInFolder}.{index}.jpg");
                index++;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Your operation was complete. Press any button to continue.");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }

        public void ResizeImages()
        {
            int width,height;
            int index = 1;
            
            Console.Write("Enter image width: ");
            int.TryParse(Console.ReadLine(), out width);
            
            Console.Write("Enter image height: ");
            int.TryParse(Console.ReadLine(),out height);

            Console.Clear();

            string[] files = Directory.GetFiles(oldFilePath);
            foreach (var item in files)
            {
                Bitmap bmp = new Bitmap(item);
                Bitmap image = new Bitmap(bmp, width, height);
                image.Save($"{newFilePath}/{index}.jpg");
                index++;
            }
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Your operation was complete. Press any button to continue.");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }

    }
}