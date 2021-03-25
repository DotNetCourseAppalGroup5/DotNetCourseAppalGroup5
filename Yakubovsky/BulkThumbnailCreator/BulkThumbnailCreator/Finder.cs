using System.IO;
using System;
using System.Threading;
using System.Drawing;

namespace BulkThumbnailCreator
{
    public class Finder
    {
        public const string oldFilePath = "/Users/tim143/Desktop/pathStart"; // Full path of old file
        public const string newFilePath = "/Users/tim143/Desktop/pathEnd"; // Full path of new file
        
        public void RenameImages()
        {
            if ((!Directory.Exists(oldFilePath)) || (!Directory.Exists(newFilePath)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                
                Console.WriteLine("Oops.We can't find this directory.");
                throw new DirectoryNotFoundException();
            }
            
            DirectoryInfo directoryInfo = new DirectoryInfo(oldFilePath);
            FileInfo[] files = directoryInfo.GetFiles();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter new name for all files: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string newNameForAllFilesInFolder = Console.ReadLine();
            Console.ResetColor();

            FileExtension fileExtension = ChooseExtension();
            Console.Clear();
            
            int index = 1;
            try
            {
                foreach (var item in files)
                {
                    item.Rename($"{newNameForAllFilesInFolder}.{index}.{fileExtension}");
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
                OperationSuccessfullEnd();
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
                Console.Clear();
                
                Console.WriteLine("Oops.We can't find this directory.");
                throw new DirectoryNotFoundException();
            }
            
            FileExtension fileExtension = ChooseExtension();
            Console.Clear();
            
            string[] files = Directory.GetFiles(oldFilePath);
            try
            {
                foreach (var item in files)
                {
                    Bitmap bmp = new Bitmap(item);
                    Bitmap image = new Bitmap(bmp, width, height);
                    image.Save($"{newFilePath}/{index}.{fileExtension}");
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
                OperationSuccessfullEnd();
            }
        }
        
        private void TryParseMethod(ref int width,ref int height)
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

        private void ShowFileExtention()
        { 
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"1){FileExtension.jpeg}");
            Console.WriteLine($"2){FileExtension.jpg}");
            Console.WriteLine($"3){FileExtension.png}");
            Console.WriteLine($"4){FileExtension.ai}");
            Console.WriteLine($"5){FileExtension.bmp}");
            Console.WriteLine($"6){FileExtension.eps}");
            Console.WriteLine($"7){FileExtension.pdf}");
            Console.WriteLine($"8){FileExtension.psd}");
            Console.WriteLine($"9){FileExtension.tiff}");
            Console.ResetColor();
        }

        private FileExtension ChooseExtension()
        {
            ShowFileExtention();
            
            Console.Write("Now,enter file extention number: ");
            char voice = Console.ReadKey().KeyChar;
            switch (voice)
            {
                    case '1': return FileExtension.jpeg;
                    case '2': return FileExtension.jpg;
                    case '3': return FileExtension.png;
                    case '4': return FileExtension.ai;
                    case '5': return FileExtension.bmp;
                    case '6': return FileExtension.eps;
                    case '7': return FileExtension.pdf;
                    case '8': return FileExtension.psd;
                    case '9': return FileExtension.tiff;
                    default: throw new ArgumentException("Invalid operation code.");
            }
        }

        private void OperationSuccessfullEnd()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Your operation was complete. Press any button to continue.");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
 