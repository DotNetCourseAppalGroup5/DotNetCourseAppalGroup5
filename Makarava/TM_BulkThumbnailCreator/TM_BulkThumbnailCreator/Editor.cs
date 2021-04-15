using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Configuration;

namespace TM_BulkThumbnailCreator
{
    public class Editor
    {
        //set initial folder
        public static string initialFolder = ConfigurationManager.AppSettings.Get("initialFolder");
        //set folder for files after changes
        public static string folderAfterChanges = ConfigurationManager.AppSettings.Get("folderAfterChanges");

        public static void CreateFolders()
        {
            if (!Directory.Exists(initialFolder))
            {
                Directory.CreateDirectory(initialFolder);
            }

            if (!Directory.Exists(folderAfterChanges))
            {
                Directory.CreateDirectory(folderAfterChanges);
            }
        }

        //set pictures Width
        public static int width = int.Parse(ConfigurationManager.AppSettings.Get("pictureWidth"));
        //set pictures Height
        public static int height = int.Parse(ConfigurationManager.AppSettings.Get("pictureHeight"));

        private static FileInfo[] FindPictures(out string[] pictureNames)
        {
            // to find files in initial folder
            DirectoryInfo folder = new DirectoryInfo(initialFolder);

            FileInfo[] pictures = folder.GetFiles();

            int filesCount = pictures.Length;

            // get pictures names
            pictureNames = Directory.GetFiles(initialFolder);

            return pictures;
        }

        public static void ResizeImages(CancellationToken token)
        {
            //get all files
            FileInfo[] files = FindPictures(out string[] pictureNames);

            int totalFiles = pictureNames.Length;

            for (int i = 0; i < totalFiles; i++)
            {
                // if user cancels the operation it will break and show how much files are done and how much are left
                if (token.IsCancellationRequested)
                {
                    Constant.ShowCancellationMessage();

                    return;
                }

                // if image is successfully processed it goes to the processed files directory
                try
                {
                    Bitmap imageToResize = new Bitmap(new Bitmap(pictureNames[i]), width, height);

                    imageToResize.Save($"{folderAfterChanges}\\{files[i].Name}");
                }

                catch
                {
                    Constant.Warning();
                }
            }

            Constant.ShowCancellationMessage();
        }

        public static void RenameImages(CancellationToken token, string userPictureName)
        {
            // getting files from the source directory
            FileInfo[] files = FindPictures(out string[] pictureNames);

            int imageIndex = 0;

            for (int i = 0; i < pictureNames.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Constant.ShowCancellationMessage();

                    return;
                }

                try
                {
                    Bitmap imageToRename = new Bitmap(pictureNames[i]);

                    imageToRename.Save($"{folderAfterChanges}\\{userPictureName} ({imageIndex}){files[i].Extension}");

                    imageIndex++;
                }

                catch
                {
                    Constant.Warning();
                }

                Constant.ShowCancellationMessage();
            }
        }
    }
}