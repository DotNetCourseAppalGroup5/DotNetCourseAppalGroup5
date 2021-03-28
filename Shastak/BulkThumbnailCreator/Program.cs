using System;
using System.Threading;
using System.Threading.Tasks;
using BulkThumbnailCreator.Extras;

namespace BulkThumbnailCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating all necessary project folders
            DirectoryHandler.CreateProjectStructure();

            // creating cancellation token for tasks
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            bool isProgramStarted = true;

            SayHello();

            do
            {
                ShowMenu();

                Task task;

                string userInput = Console.ReadLine().Trim().ToUpper();
                Enum.TryParse(userInput, out MenuActions action);

                switch (action)
                {
                    // doing image resizing
                    case MenuActions.ResizeImages:
                        ImageHandler.GetSize(out ushort width, out ushort height);
                        task = Task.Run(() => ImageHandler.ResizeImages(width, height, token));

                        AskForOperationCancel(tokenSource);

                        break;

                    // doing image renaming
                    case MenuActions.RenameImages:
                        ImageHandler.GetName(out string newImageName);
                        task = Task.Run(() => ImageHandler.RenameImages(newImageName, token));

                        AskForOperationCancel(tokenSource);

                        break;

                    // exiting the program
                    case MenuActions.Exit:
                        TextColorizer.WriteTextInColor("\nThank you for using BulkThumbnailCreator. Come back soon!", ConsoleColor.Green);
                        isProgramStarted = false;

                        Console.ReadKey();
                        
                        break;

                    // handling incorrect input
                    default:
                        TextColorizer.WriteTextInColor("\nUnrecognized command. Press any key to get back to the main menu..", ConsoleColor.Yellow);
                        
                        Console.ReadKey();
                        
                        break;
                }

                Console.Clear();
            }
            while (isProgramStarted);
        }

        private static void AskForOperationCancel(CancellationTokenSource tokenSource)
        {
            TextColorizer.WriteTextInColor("\nTo abort operation type Q. ", ConsoleColor.Yellow, false);

            string userInput = Console.ReadLine().Trim().ToUpper();

            if (userInput == "Q")
                tokenSource.Cancel();
        }

        private static void SayHello()
        {
            Console.Clear();

            Console.Write("Welcome to the ");
            TextColorizer.WriteTextInColor("BulkThumbnailCreator", ConsoleColor.Green, false);
            Console.WriteLine("! \nThis program allows you to resize or rename your images.");
            Console.WriteLine("All your processed images will be stored in Processed Files folder.");
            Console.WriteLine("Please make sure you have all needed images in Source Files folder.");
            Console.WriteLine();
        }

        private static void ShowMenu()
        {
            TextColorizer.WriteTextInColor("Please type one of the following commands (without quotes): ", ConsoleColor.Yellow);
            Console.WriteLine("'1' - Resize images");
            Console.WriteLine("'2' - Rename images");
            Console.WriteLine("'3' - Exit program");
            TextColorizer.WriteTextInColor("Your input: ", ConsoleColor.Green, false);
        }
    }
}
