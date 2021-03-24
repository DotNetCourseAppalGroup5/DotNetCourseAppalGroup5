using System.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace BulkThumbnailCreator
{
    public class Finder
    {
        public const string oldFilePath = "/Users/tim143/Desktop/pathStart"; // Full path of old file
        public const string newFilePath = "/Users/tim143/Desktop/pathEnd"; // Full path of new file
        
        public void RenameImages(CancellationToken token)
        {
            if ((!Directory.Exists(oldFilePath)) || (!Directory.Exists(newFilePath)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops.We can't find this directory.");
                
                //Thinking about to throw new DirectoryNotFoundException here.
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            
            DirectoryInfo directoryInfo = new DirectoryInfo(oldFilePath);
            FileInfo[] files = directoryInfo.GetFiles();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter new name for all files: ");
            string newNameForAllFilesInFolder = Console.ReadLine();
            Console.ResetColor();
            
            int index = 1;
            try
            {
                foreach (var item in files)
                {
                    item.Rename($"{newNameForAllFilesInFolder}.{index}.jpg");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was an exception. " + ex.Message);
                Thread.Sleep(3000);
                Console.Clear();
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Your operation was complete. Press any button to continue.");
                Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
            }
        }

        public void ResizeImages()
        {
            int width=0,height=0;
            int index = 1;

            TryParseMethod(ref width,ref height);
            Console.Clear();

            if ((!Directory.Exists(oldFilePath)) || (!Directory.Exists(newFilePath)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops.We can't find this directory.");
                
                //Thinking about to throw new DirectoryNotFoundException here.
                Thread.Sleep(3000);
                Environment.Exit(0);
            }

            string[] files = Directory.GetFiles(oldFilePath);
            try
            {
                foreach (var item in files)
                {
                    Bitmap bmp = new Bitmap(item);
                    Bitmap image = new Bitmap(bmp, width, height);
                    image.Save($"{newFilePath}/{index}.jpg");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was an exception. " + ex.Message);
                Thread.Sleep(3000);
                Console.Clear();
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Your operation was complete. Press any button to continue.");
                Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
            }
        }
        
        public void TryParseMethod(ref int width,ref int height)
        {
            string widthStr = null, heightStr = null;

            bool widthConvert = true;
            while (widthConvert)
            {
                Console.Write("Enter width, that you expect to see in your new image: ");
                widthStr = Console.ReadLine();

                if (!(int.TryParse(widthStr, out width)))
                {
                    Console.WriteLine("It must be an integer number. Try again.");
                }
                else
                {
                    widthConvert = false;
                    Console.Clear();
                }
            }
            
            bool heightConvert = true;
            while (heightConvert)
            {
                Console.Write("Enter height, that you expect to see in your new image: ");
                heightStr = Console.ReadLine();

                if (!(int.TryParse(heightStr, out height)))
                {
                    Console.WriteLine("It must be an integer number. Try again.");
                }
                else
                {
                    heightConvert = false;
                    Console.Clear();
                }
            }
        }
    }
}