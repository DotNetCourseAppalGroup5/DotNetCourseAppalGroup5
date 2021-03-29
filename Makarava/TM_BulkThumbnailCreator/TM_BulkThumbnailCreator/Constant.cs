using System;
using System.Threading;

namespace TM_BulkThumbnailCreator
{
    static public class Constant
    {
        public static string mainMenu = "\tPlease select an action to make with your pictures: " +
                "\n\t1.Size changing" +
                "\n\t2.Rename all images";

        public static string userMessageForRename = "\tPlease type common name for all pictures:";

        public static string userMessageForResize = "\tResizing process is started";

        public static string notificationToReturnToMainMenu = "\tYour process is done. Type anything to return to main menu";

        public static string cancellationMessage = "\tYour process is done. Type anything to return to main menu";

        public static void WelcomingMessage(string initialFolder, string folderAfterChanges)
        {
            //welcoming message
            Console.WriteLine($"\n\tHi user! Welcome to Bulk Thumbnail Creator." +
                $"\n\n\tPlease upload images you want to work with into the following folder " +
                $"\n\n\t{initialFolder} folder. " +
                $"\n\n\tAfter editing your pictures will be saved into " +
                $"\n\n\t{folderAfterChanges}" +
                $"\n\n\t Note: You can change folders in App.config file");

            Console.WriteLine("\n\n\t Please type anything to go to the main menu");
            Console.ReadKey();
            Console.Clear();
        }

        public static void WrongInput()
        {
            //red color for warning
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();

            //warning message
            Console.WriteLine("\t You've inputted wrong command. Type anything to be returned to the main menu.");

            //reset the color
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void Warning(string errorFileName)
        {
            //red color for warning
            Console.ForegroundColor = ConsoleColor.DarkRed;

            //warning message
            Console.WriteLine($"\t File {errorFileName} is not a picture and will not be processed. ");

            //reset the color
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void CancellationMessage(CancellationTokenSource cancelationTokenSource)
        {
            Console.WriteLine($"\n\tPlease type Q to cancel process");

            string cancelInput = Console.ReadLine().Trim().ToUpper();
            
            if (cancelInput == "Q")
            {
                cancelationTokenSource.Cancel();
            }
        }
    }
}
