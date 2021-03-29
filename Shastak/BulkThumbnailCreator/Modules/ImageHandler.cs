using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using BulkThumbnailCreator.Extras;

namespace BulkThumbnailCreator.Modules
{
    public static class ImageHandler
    {
        private static FileInfo[] Files { get; set; }
        private static string[] Filenames { get; set; }

        public static void ResizeImages(ushort width, ushort height, CancellationToken token)
        {
            // deleting all the files in the processed files folder
            ClearProcessedFilesFolder();

            // starting working with images
            bool isOperationAborted = false;
            int totalFiles = Filenames.Length;
            int processedFiles = 0;
            int skippedFiles = 0;
            int filesDone = 0;

            int length = 0;

            for (int i = 0; i < totalFiles; i++)
            {
                // if user cancels the operation it will break and show how much files are done and how much are left
                if (token.IsCancellationRequested)
                {
                    isOperationAborted = true;
                    skippedFiles = totalFiles - processedFiles;

                    DisplayOperationResult(isOperationAborted, $"{Constants.operationAborted} {Environment.UserName}.", processedFiles, skippedFiles);

                    return;
                }

                // if image is successfully processed it goes to the processed files directory
                try
                {
                    BtcLogger.WriteLocalLogs($"Starting resizing file {Files[i].Name}");

                    Bitmap sourceImage = new Bitmap(Filenames[i]);
                    Bitmap imageToResize = new Bitmap(sourceImage, width, height);
                    imageToResize.Save($"{DirectoryHandler.ProcessedFiles}\\{Files[i].Name}");

                    processedFiles++;
                    filesDone++;

                    sourceImage.Dispose();
                    imageToResize.Dispose();

                    BtcLogger.WriteLocalLogs($"File {Files[i].Name} is resized succesfully");
                }

                // if some exception is catched (e.g. file is not an image), then the file is skipped and amount of such files is incremented
                catch (Exception ex)
                {
                    BtcLogger.WriteLocalLogs($"Error during resizing {Files[i].Name}. Error message: {ex.Message}");
                    skippedFiles++;
                    filesDone++;
                }

                // showing the progress of processing
                finally
                {
                    DisplayProgress.Show(totalFiles, filesDone, ref length);
                    Console.CursorLeft = DisplayProgress.CursorOffset;
                }
            }

            // displaying operation results
            DisplayOperationResult(isOperationAborted, Constants.operationCompleted, processedFiles, skippedFiles);
        }

        public static void RenameImages(string newImageName, CancellationToken token)
        {
            // deleting all the files in the processed files folder
            ClearProcessedFilesFolder();

            // starting working with images
            bool isOperationAborted = false;
            int totalFiles = Filenames.Length;
            int processedFiles = 0;
            int skippedFiles = 0;
            int imageNumber = 0;
            int filesDone = 0;

            int length = 0;

            for (int i = 0; i < Filenames.Length; i++)
            {
                // if user cancels the operation it will break and show how much files are done and how much are left
                if (token.IsCancellationRequested)
                {
                    isOperationAborted = true;
                    skippedFiles = totalFiles - processedFiles;

                    DisplayOperationResult(isOperationAborted, $"{Constants.operationAborted} {Environment.UserName}.", processedFiles, skippedFiles);
                }

                // if image is succefully processed it goes to the processed files directory
                try
                {
                    BtcLogger.WriteLocalLogs($"Starting renaming file {Files[i].Name}");

                    Bitmap imageToRename = new Bitmap(Filenames[i]);
                    imageToRename.Save($"{DirectoryHandler.ProcessedFiles}\\{newImageName} ({imageNumber}){Files[i].Extension}");

                    imageNumber++;
                    processedFiles++;
                    filesDone++;

                    imageToRename.Dispose();

                    BtcLogger.WriteLocalLogs($"File {Files[i].Name} is renamed succesfully");
                }

                // if some exception is catched (e.g. file is not an image), then the file is skipped and amount of such files is incremented
                catch (Exception ex)
                {
                    BtcLogger.WriteLocalLogs($"Error during resizing {Files[i].Name}. Error message: {ex.Message}");
                    skippedFiles++;
                    filesDone++;
                }

                // showing the progress of processing
                finally
                {
                    DisplayProgress.Show(totalFiles, filesDone, ref length);
                    Console.CursorLeft = DisplayProgress.CursorOffset;
                }
            }

            // displaying operation results
            DisplayOperationResult(isOperationAborted, Constants.operationCompleted, processedFiles, skippedFiles);
        }

        public static void GetName(out string name)
        {
            // asking user for new name for the images
            TextColorizer.WriteTextInColor("\nPlease enter new name for the files: ", ConsoleColor.Yellow, false);
            name = Console.ReadLine().Trim();

            Console.WriteLine();
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

            Console.WriteLine();
        }

        public static void GetFiles()
        {
            // getting files from the source directory and counting amount of files
            DirectoryInfo folder = new DirectoryInfo(DirectoryHandler.SourceFiles);
            Files = folder.GetFiles();
            int filesCount = Files.Length;

            // if there are no files in the source folder show a warning message for user to add files
            while (filesCount == 0)
            {
                TextColorizer.WriteTextInColor(Constants.noFilesInSourceFolder, ConsoleColor.Yellow);

                Console.ReadKey();

                Files = folder.GetFiles();
                filesCount = Files.Length;
            }

            // getting names of all the files in the source folder
            Filenames = Directory.GetFiles(DirectoryHandler.SourceFiles);
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

            // writing local logs
            BtcLogger.WriteLocalLogs($"{message} Processed images: {processedFiles}, skipped files: {skippedFiles}");

            TextColorizer.WriteTextInColor("\nPress Enter to get back to the main menu..", ConsoleColor.Yellow);
        }
    }
}
