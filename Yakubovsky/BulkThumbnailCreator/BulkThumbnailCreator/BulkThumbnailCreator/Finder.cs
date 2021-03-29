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
        private string oldFilePath = ConfigurationManager.AppSettings.Get("PathStart"); // Full path of old file
        private string newFilePath = ConfigurationManager.AppSettings.Get("PathEnd"); // Full path of new file
        
        public void RenameImages()
        {
            if ((!Directory.Exists(oldFilePath)) || (!Directory.Exists(newFilePath)))
            {
                throw new DirectoryNotFoundException();
            }
            
            DirectoryInfo directoryInfo = new DirectoryInfo(oldFilePath);
            FileInfo[] files = directoryInfo.GetFiles();

            string newNameForAllFilesInFolder = ConfigurationManager.AppSettings.Get("NewFileName");

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
                Console.WriteLine(Constansts.ErrorMessages.ErrorMessage + ex.Message);
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
            
            width = int.Parse(ConfigurationManager.AppSettings.Get("Width"));
            height = int.Parse(ConfigurationManager.AppSettings.Get("Height"));

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
                Console.WriteLine(Constansts.ErrorMessages.ErrorMessage + ex.Message);
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
            Console.WriteLine($"1){FileExtension.jpeg}");
            Console.WriteLine($"2){FileExtension.jpg}");
            Console.WriteLine($"3){FileExtension.png}");
            Console.WriteLine($"4){FileExtension.ai}");
            Console.WriteLine($"5){FileExtension.bmp}");
            Console.WriteLine($"6){FileExtension.eps}");
            Console.WriteLine($"7){FileExtension.pdf}");
            Console.WriteLine($"8){FileExtension.psd}");
            Console.WriteLine($"9){FileExtension.tiff}");
        }

        private FileExtension ChooseExtension()
        {
            ShowFileExtention();
            
            FileExtension fl;
            Console.Write(Constansts.FileExtensions.FileExtensionChoice);
            Enum.TryParse(Console.ReadLine().ToLower(), out fl);
            
            switch (fl)
            {
                    case FileExtension.jpeg : return FileExtension.jpeg;
                    case FileExtension.jpg: return FileExtension.jpg;
                    case FileExtension.png: return FileExtension.png;
                    case FileExtension.ai: return FileExtension.ai;
                    case FileExtension.bmp: return FileExtension.bmp;
                    case FileExtension.eps: return FileExtension.eps;
                    case FileExtension.pdf: return FileExtension.pdf;
                    case FileExtension.psd: return FileExtension.psd;
                    case FileExtension.tiff: return FileExtension.tiff;
                    default: throw new ArgumentException();
            }
        }

        private void OperationSuccessfullEnd()
        {
            Console.WriteLine(Constansts.UserNotifications.NotifyComplete);
            Console.ReadKey();
            Console.Clear();
        }
    }
}

 