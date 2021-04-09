using System;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BulkThumbnailCreator
{
    public class ManagmentPicture
    {
        public int ImageWidth { get; set; } = int.Parse(ConfigurationManager.AppSettings.Get("imageWidth"));
        public int ImageHeight { get; set; } = int.Parse(ConfigurationManager.AppSettings.Get("imageHeight"));
        public string PathWithPicture { get; set; } = ConfigurationManager.AppSettings["pathWithPicture"];
        public string PathPictureAfterCopy { get; set; } = ConfigurationManager.AppSettings["pathPictureAfterCopy"];
        public static PictureFormat Format { get; set; }

        public void CreateDirectoryForPicture()
        {
            DirectoryInfo directory = new DirectoryInfo(PathPictureAfterCopy);
            if (!directory.Exists)
            {
                directory.Create();
                WorkWithText.ShowMessage($"Folder create. Folder path: {directory.FullName}");
                return;
            }
            WorkWithText.ShowErrorMessage($"Folder exists. Folder path: {directory.FullName}");
        }

        public async Task RenameFilesAsync()
        {
            if (Directory.GetFiles(PathPictureAfterCopy).Length == 0)
            {
                WorkWithText.ShowErrorMessage("There are no images in this folder.");
                return;
            }

            int i = 1;
            string newName = EnterNameFile();
            List<Task> tasks = new List<Task>();

            DirectoryInfo directory = new DirectoryInfo(PathPictureAfterCopy);
            foreach (FileInfo file in directory.GetFiles())
            {
                string newFilesName = file.FullName.Replace($"{file.FullName}", $"{file.DirectoryName}\\" +
                                      $"{i++}_{newName}{Path.GetExtension(file.Name)}");
                tasks.Add(Task.Run(() => File.Move(file.FullName, newFilesName)));
            }
            try
            {
                await Task.WhenAll(tasks);
                WorkWithText.ShowMessage($"File rename seccessful.");
            }
            catch (SystemException ex)
            {
                WorkWithText.ShowErrorMessage($"{ex.Message}");
            }
        }

        public async Task DeleteFileFromFolderAsync()
        {
            if (Directory.GetFiles(PathPictureAfterCopy).Length == 0)
            {
                WorkWithText.ShowErrorMessage("There are no images in this folder.");
                return;
            }

            List<Task> tasks = new List<Task>();
            DirectoryInfo directory = new DirectoryInfo(PathPictureAfterCopy);
            foreach (FileInfo file in directory.GetFiles())
            {
                tasks.Add(Task.Run(() => file.Delete()));
            }
            try
            {
                await Task.WhenAll(tasks);
                WorkWithText.ShowMessage("Images delete from folder successfull.");
            }
            catch (SystemException ex)
            {
                WorkWithText.ShowErrorMessage($"{ex.Message}");
            }
        }

        public async Task ChangeFilesExtensionAsync()
        {
            int i = 1;
            if (Directory.GetFiles(PathPictureAfterCopy).Length == 0)
            {
                WorkWithText.ShowErrorMessage("There are no images in this folder.");
                return;
            }

            ChooseExtensionImage();
            List<Task> tasks = new List<Task>();

            DirectoryInfo directory = new DirectoryInfo(PathPictureAfterCopy);
            foreach (FileInfo file in directory.GetFiles())
            {
                string filesNewFormat = file.Name.Replace($"{file.Name}", $"{file.DirectoryName}\\" +
                                        $"{i++}_{Path.GetFileNameWithoutExtension(file.Name)}.{Format}");

                tasks.Add(Task.Run(() => File.Move(file.FullName, filesNewFormat)));
            }
            try
            {
                await Task.WhenAll(tasks);
                WorkWithText.ShowMessage("Images extension changed successfully.");
            }
            catch (SystemException ex)
            {
                WorkWithText.ShowErrorMessage($"{ex.Message}");
            }
        }

        public async Task CopyFilesInNewFolderAsync()
        {
            void CopyFilesInNewFolder()
            {
                foreach (var fileName in Directory.GetFiles(PathWithPicture))
                {
                    using (var image = Image.FromFile(fileName))
                    {
                        if (image.Width <= ImageWidth && image.Height <= ImageHeight)
                        {
                            var newFileName = Path.Combine(PathPictureAfterCopy, Path.GetFileName(fileName));

                            image.Save(newFileName);

                        }
                    }
                }
            }
            try
            {
                await Task.Run(() => CopyFilesInNewFolder());
                WorkWithText.ShowMessage("Files copy in new folder!");
            }
            catch (Exception ex)
            {
                WorkWithText.ShowErrorMessage($"Exception: {ex.Message}. Click 1 to create folder.");
            }
        }

        private void ChooseExtensionImage()
        {
            var formats = Enum.GetNames(typeof(PictureFormat));
            for (int i = 0; i < formats.Length; i++)
            {
                WorkWithText.ShowMessage($"{i+1} - {formats[i]}");
            }
            int command = EnterCorrectCommand();
            FormattingPicture(command);
        }
        
        private int EnterCorrectCommand()
        {
            int command;

            while (!int.TryParse(Console.ReadLine(), out command))
            {
                WorkWithText.ShowErrorMessage("Enter please correct extension images");
            }
           
            while (!Enum.IsDefined(typeof(PictureFormat), command))
            {
                WorkWithText.ShowErrorMessage("Select an extension from the list of suggested.");
                while (!int.TryParse(Console.ReadLine(), out command))
                {
                    WorkWithText.ShowErrorMessage("Enter please correct extension images");
                }
            }
            return command;
        }

        private string EnterNameFile()
        {
            WorkWithText.ShowInformationMessage("Enter please file name:");
            string newName = Console.ReadLine();

            while (string.IsNullOrEmpty(newName))
            {
                WorkWithText.ShowErrorMessage("Enter please name files");
            }

            return newName;
        }

        private void FormattingPicture(int command)
        {
            Format = (PictureFormat)(command);
        }
    }
}