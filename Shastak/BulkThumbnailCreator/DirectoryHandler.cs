using System;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using BulkThumbnailCreator.Extras;

namespace BulkThumbnailCreator
{
    public static class DirectoryHandler
    {
        public static string SourceFiles { get; private set; }
        public static string ProcessedFiles { get; private set; }
        public static string Logs { get; private set; }

        public static void CreateProjectStructure()
        {
            Logs = CreateFolder("logsFolderPath");
            SourceFiles = CreateFolder("sourceFilesPath");
            ProcessedFiles = CreateFolder("processedFilesPath");
        }

        private static string CreateFolder(string type)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string projectDirectory = desktopPath + "\\Bulk Thumbnail Creator";
            string path = projectDirectory + ConfigurationManager.AppSettings.Get(type);

            // checking if folder exists or not. If not, then create the needed one and write log entries
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                string message = $"The following folder has been created: {path}";

                EventLogger.WriteLogs(message, EventLogEntryType.Information);
                BTCLogger.WriteLocalLogs(message);
            }

            return path;
        }
    }
}
