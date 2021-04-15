using System;
using System.Threading.Tasks;
using System.Threading;

namespace TM_BulkThumbnailCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            //set background and Foreground color
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            WelcomingMessage(Editor.initialFolder, Editor.folderAfterChanges);

            bool returnToMainMenu = true;

            while (returnToMainMenu)
            {
                //set cansellation token
                CancellationTokenSource cancelationToken = new CancellationTokenSource();
                CancellationToken token = cancelationToken.Token;

                returnToMainMenu = false;

                Console.WriteLine($"{Constant.mainMenu}");

                var userActionChoise = Console.ReadLine();

                Enum.TryParse(userActionChoise, out MenuEnum action);

                switch (action)
                {
                    //Size changing
                    case MenuEnum.Resize:

                        Console.Clear();

                        Console.WriteLine($"{Constant.userMessageForResize}");

                        Task.Factory.StartNew(() => Editor.ResizeImages(token));

                        CancellationMessage(cancelationToken);

                        Console.Clear();

                        returnToMainMenu = true;

                        break;

                    //Rename all images
                    case MenuEnum.Rename:

                        Console.Clear();

                        Console.WriteLine($"{Constant.userMessageForRename}");

                        string userPictureName = Console.ReadLine();

                        Task.Factory.StartNew(() => Editor.RenameImages(token, userPictureName));

                        CancellationMessage(cancelationToken);

                        Console.Clear();

                        returnToMainMenu = true;

                        break;

                    default:

                        Constant.WrongInput();

                        Console.ReadKey();

                        Console.Clear();

                        returnToMainMenu = true;

                        break;
                }
            }
        }

        static void WelcomingMessage(string initialFolder, string folderAfterChanges)
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

        static void CancellationMessage(CancellationTokenSource cancelationTokenSource)
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