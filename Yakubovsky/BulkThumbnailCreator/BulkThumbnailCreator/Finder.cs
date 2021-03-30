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
        
        public void RenameImages(string newNameForAllFilesInFolder)
        {
            if ((!Directory.Exists(oldFilePath)) || (!Directory.Exists(newFilePath)))
            {
                throw new DirectoryNotFoundException();
            }
            
            DirectoryInfo directoryInfo = new DirectoryInfo(oldFilePath);
            FileInfo[] files = directoryInfo.GetFiles();

            int index = 1;
            try
            {
                foreach (var item in files)
                {
                    item.Rename($"{newNameForAllFilesInFolder}.{index}{item.Extension}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constansts.ErrorMessages.ErrorMessage + ex.Message);
                Thread.Sleep(3000);
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
            
            string[] files = Directory.GetFiles(oldFilePath);
            try
            {
                foreach (var item in files)
                {
                    Bitmap bmp = new Bitmap(item);
                    Bitmap image = new Bitmap(bmp, width, height);
                    image.Save($"{newFilePath}/{index}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constansts.ErrorMessages.ErrorMessage + ex.Message);
                Thread.Sleep(3000);
            }
        }
    }
}

 