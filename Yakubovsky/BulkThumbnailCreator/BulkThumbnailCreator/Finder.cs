using System.IO;
using System;
using System.Threading;
using System.Drawing;
using System.Configuration;
using System.Collections.Specialized;
using BulkThumbnailCreator.Properties;

namespace BulkThumbnailCreator
{
    public class Finder
    {
        public string oldFilePath = ConfigurationManager.AppSettings.Get("PathStart"); // Full path of old file
        public string newFilePath = ConfigurationManager.AppSettings.Get("PathEnd"); // Full path of new file
        
        public void RenameImages()
        {
            if ((!Directory.Exists(oldFilePath)) || (!Directory.Exists(newFilePath)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                
                Console.WriteLine(Constansts.ErrorMessages.ErrorMessageDirectoryNotFound);
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
            
            string widthConfig=ConfigurationManager.AppSettings.Get("Width");
            width = int.Parse(widthConfig);
            
            string heightConfig=ConfigurationManager.AppSettings.Get("Height");
            height = int.Parse(heightConfig);

            if ((!Directory.Exists(oldFilePath)) || (!Directory.Exists(newFilePath)))
            {
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

 