using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using BulkThumbnailCreator.Extras;

namespace BulkThumbnailCreator
{
    public static class ImageHandler
    {
        public static void ResizeImages(ushort width, ushort height, CancellationToken token)
        {
            // deleting all the files in the processed files folder
            ClearProcessedFilesFolder();

            // getting files from the source directory
            FileInfo[] files = GetFiles(out string[] filenames);

            // starting working with images
            bool isOperationAborted = false;
            int totalFiles = filenames.Length;
            int processedFiles = 0;
            int skippedFiles = 0;

            for (int i = 0; i < totalFiles; i++)
            {
                // if user cancels the operation it will break and show how much files are done and how much are left
                if (token.IsCancellationRequested)
                {
                    isOperationAborted = true;
                    skippedFiles = totalFiles - processedFiles;

                    DisplayOperationResult(isOperationAborted, "Operation was aborted by user.", processedFiles, skippedFiles);

                    return;
                }

                // if image is successfully processed it goes to the processed files directory
                try
                {
                    Bitmap sourceImage = new Bitmap(filenames[i]);
                    Bitmap imageToResize = new Bitmap(sourceImage, width, height);
                    imageToResize.Save($"{DirectoryHandler.ProcessedFiles}\\{files[i].Name}{files[i].Extension}");

                    processedFiles++;

                    sourceImage.Dispose();
                    imageToResize.Dispose();
                }

                // if some exception is catched (e.g. file is not an image), then the file is skipped and amount of such files is incremented
                catch
                {
                    skippedFiles++;
                }
            }

            // displaying operation results
            DisplayOperationResult(isOperationAborted, "Operation is completed successfully!", processedFiles, skippedFiles);
        }

        public static void RenameImages(string newImageName, CancellationToken token)
        {
            // deleting all the files in the processed files folder
            ClearProcessedFilesFolder();

            // getting files from the source directory
            FileInfo[] files = GetFiles(out string[] filenames);

            // starting working with images
            bool isOperationAborted = false;
            int totalFiles = filenames.Length;
            int processedFiles = 0;
            int skippedFiles = 0;
            int imageNumber = 0;

            for (int i = 0; i < filenames.Length; i++)
            {
                // if user cancels the operation it will break and show how much files are done and how much are left
                if (token.IsCancellationRequested)
                {
                    isOperationAborted = true;
                    skippedFiles = totalFiles - processedFiles;

                    DisplayOperationResult(isOperationAborted, "Operation was aborted by user.", processedFiles, skippedFiles);
                }

                // if image is succefully processed it goes to the processed files directory
                try
                {
                    Bitmap imageToRename = new Bitmap(filenames[i]);
                    imageToRename.Save($"{DirectoryHandler.ProcessedFiles}\\{newImageName} ({imageNumber}){files[i].Extension}");

                    imageNumber++;
                    processedFiles++;

                    imageToRename.Dispose();
                }

                // if some exception is catched (e.g. file is not an image), then the file is skipped and amount of such files is incremented
                catch
                {
                    skippedFiles++;
                }
            }

            // displaying operation results
            DisplayOperationResult(isOperationAborted, "Operation is completed successfully!", processedFiles, skippedFiles);
        }

        public static void GetName(out string name)
        {
            // asking user for new name for the images
            TextColorizer.WriteTextInColor("\nPlease enter new name for the files: ", ConsoleColor.Yellow, false);

            name = Console.ReadLine().Trim();
        }

        public static void GetSize(out ushort width, out ushort height)
        {
            // asking user for size in pixels for each dimension
            TextColorizer.WriteTextInColor("\nPLEASE PAY ATTENTION!", ConsoleColor.Red);
            Console.WriteLine("To avoid huge usage of your hard drive memory the maximum size for one dimesion equals to 4096 pixels.");

            TextColorizer.WriteTextInColor("\nPlease enter preferable width: ", ConsoleColor.Yellow, false);
            width = ParsingChecker.SetPixels();

            TextColorizer.WriteTextInColor("Please enter preferable heigth: ", ConsoleColor.Yellow, false);
            height = ParsingChecker.SetPixels();
        }

        private static FileInfo[] GetFiles(out string[] filenames)
        {
            // getting files from the source directory and counting amount of files
            DirectoryInfo folder = new DirectoryInfo(DirectoryHandler.SourceFiles);
            FileInfo[] files = folder.GetFiles();
            int filesCount = files.Length;

            // if there are no files in the source folder show a warning message for user to add files
            while (filesCount == 0)
            {
                TextColorizer.WriteTextInColor(
                    "Your source folder doesn't contain any files! \n" +
                    "Please add some files in the source folder and press any key to continue. \n",
                    ConsoleColor.Yellow
                    );

                Console.ReadKey();

                files = folder.GetFiles();
                filesCount = files.Length;
            }

            // getting names of all the files in the source folder
            filenames = Directory.GetFiles(DirectoryHandler.SourceFiles);

            return files;
        }

        private static void ClearProcessedFilesFolder()
        {
            // checking are there any files in the processed files folder
            DirectoryInfo folder = new DirectoryInfo(DirectoryHandler.ProcessedFiles);
            FileInfo[] files = folder.GetFiles();
            int filesCount = files.Length;

            // if yes, then delete all the files
            if (filesCount != 0)
                foreach (var item in files)
                    item.Delete();
        }

        private static void DisplayOperationResult(bool isOperationAborted, string message, int processedFiles, int skippedFiles)
        {
            if (isOperationAborted)
                TextColorizer.WriteTextInColor($"\n{message}", ConsoleColor.Red);
            else
                TextColorizer.WriteTextInColor($"\n\n{message}", ConsoleColor.Green);

            if (processedFiles != 0)
                Console.WriteLine($"Processed images: {processedFiles}");

            if (skippedFiles != 0)
                Console.WriteLine($"Skipped files: {skippedFiles}");

            // writing log entries to the Event Viewer
            EventLogEntryType eventLogType = isOperationAborted ? EventLogEntryType.Warning : EventLogEntryType.Information;
            EventLogger.WriteLogs($"{message} Processed images: {processedFiles}, skipped files: {skippedFiles}.", eventLogType);

            TextColorizer.WriteTextInColor("\nPress Enter to get back to the main menu..", ConsoleColor.Yellow);
        }
    }
}
