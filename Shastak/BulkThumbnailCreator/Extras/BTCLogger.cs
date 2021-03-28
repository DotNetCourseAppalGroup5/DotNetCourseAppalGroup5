﻿using System;
using System.IO;
using BulkThumbnailCreator.Modules;

namespace BulkThumbnailCreator.Extras
{
    public static class BTCLogger
    {
        private static string LogsFilename { get; set; }

        public static void WriteLocalLogs(string message)
        {
            CreateLogsFileForToday();

            using (StreamWriter sw = new StreamWriter(LogsFilename, true))
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff");
                sw.WriteLine($"[{now}] {message}.");
            }
        }

        private static void CreateLogsFileForToday()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string filename = @$"{DirectoryHandler.Logs}\{today}_logs.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff");
                    sw.WriteLine($"[{now}] Log file is created.");
                }
            }

            LogsFilename = filename;
        }
    }
}
