using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Thumbnail_Creator
{
    public class FileChecker
    {
        public FileInfo[] IsAvailableWorkingWithFiles(string filesPath, string newFilesPath)
        {
            if (!IsDirectoryExists(filesPath)) return null;
            if (!IsDirectoryExists(newFilesPath)) return null;
           
            DirectoryInfo directoryInfo = new DirectoryInfo(filesPath);
            FileInfo[] files = directoryInfo.GetFiles();

            if (!IsFileExists(files)) return null;

            return files;
        }

        bool IsDirectoryExists(string filesPath)
        {
            if (!Directory.Exists(filesPath))
            {
                Console.WriteLine("Specified directory doesn't exists!");
                Console.WriteLine("Creating new directory...");
                Console.WriteLine(filesPath);
                Directory.CreateDirectory(filesPath);
                Console.ReadKey();
                return false;
            }
            else return true;
        }

        bool IsFileExists(FileInfo[] files)
        {
            if (files.Length != 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Directory is empty!");
                Console.WriteLine("Please add some files");
                Console.ReadKey();
                return false;
            }
        }
    }
}
