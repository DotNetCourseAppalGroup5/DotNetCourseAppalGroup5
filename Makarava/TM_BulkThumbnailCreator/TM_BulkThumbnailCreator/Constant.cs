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

        public static void Warning()
        {
            //red color for warning
            Console.ForegroundColor = ConsoleColor.DarkRed;
            //warning message
            Console.WriteLine($"\t One of processed file is not a picture and will not be processed. ");
            //reset the color
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void ShowCancellationMessage()
        { 
            Console.WriteLine("\tYour process is done. Type anything to return to main menu"); 
        }
    }
}
