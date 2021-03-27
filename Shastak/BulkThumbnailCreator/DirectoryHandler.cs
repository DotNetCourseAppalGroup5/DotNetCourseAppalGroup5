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
            ProcessedFiles = CreateFolder("processedFilasPath");
        }

        private static string CreateFolder(string type)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string projectDirectory = desktopPath + "\\Bulk Thumbnail Creator";
            string path = projectDirectory + ConfigurationManager.AppSettings.Get(type);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
