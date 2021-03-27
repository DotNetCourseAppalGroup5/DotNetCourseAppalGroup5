using System;
using System.Configuration;
using System.IO;

namespace BulkThumbnailCreator
{
    public static class DirectoryHandler
    {
        public static string SourceFiles { get; private set; }
        public static string ProcessedFiles { get; private set; }

        public static void CreateProjectStructure()
        {
            SourceFiles = CreateFolder("sourceFilesPath");
            ProcessedFiles = CreateFolder("processedFilesPath");
        }

        private static string CreateFolder(string type)
        {
            // declaring path to the project folders
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string projectDirectory = desktopPath + "\\Bulk Thumbnail Creator";
            string path = projectDirectory + ConfigurationManager.AppSettings.Get(type);

            // checking if folder exists or not. If not, then create the needed one
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
