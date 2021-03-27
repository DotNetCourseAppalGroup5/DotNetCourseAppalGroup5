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

            do
            {
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
                        isProgramStarted = false;
                        break;

                    // handling incorrect input
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            while (isProgramStarted);
        }

        private static void AskForOperationCancel(CancellationTokenSource tokenSource)
        {
            TextColorizer.WriteTextInColor("\nTo abort operation type Q: ", ConsoleColor.Yellow, false);

            string userInput = Console.ReadLine().Trim().ToUpper();

            if (userInput == "Q")
                tokenSource.Cancel();
        }
    }
}
