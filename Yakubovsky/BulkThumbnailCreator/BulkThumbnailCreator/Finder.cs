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
        private string oldFilePath = ConfigurationManager.AppSettings.Get("PathStart"); 
        private string newFilePath = ConfigurationManager.AppSettings.Get("PathEnd");
        
        public void RenameImages(string newNameForFiles,CancellationToken token)
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
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    
                    item.Rename($"{newNameForFiles}.{index}{item.Extension}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constansts.ErrorMessages.ErrorMessage + ex.Message);
            }
        }

        public void ResizeImages(CancellationToken token)
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
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    
                    Bitmap bmp = new Bitmap(item);
                    Bitmap image = new Bitmap(bmp, width, height);
                    image.Save($"{newFilePath}/{index}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constansts.ErrorMessages.ErrorMessage + ex.Message);
            }
        }
    }
}

 