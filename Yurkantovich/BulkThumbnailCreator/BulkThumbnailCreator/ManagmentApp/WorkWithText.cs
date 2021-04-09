using System;

namespace BulkThumbnailCreator
{
    public class WorkWithText
    {
        public static void ShowMessage(params string[] msgs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(var msg in msgs)
            {
                Console.WriteLine(msg);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowErrorMessage(params string[] msgs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var msg in msgs)
            {
                Console.WriteLine(msg);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowInformationMessage(params string[] msgs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var msg in msgs)
            {
                Console.WriteLine(msg);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
