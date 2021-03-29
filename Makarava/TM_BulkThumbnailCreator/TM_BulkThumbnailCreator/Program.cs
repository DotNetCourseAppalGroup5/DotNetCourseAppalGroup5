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

            Constant.WelcomingMessage(Editor.initialFolder, Editor.folderAfterChanges);

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

                        Constant.CancellationMessage(cancelationToken);

                        Console.Clear();

                        returnToMainMenu = true;

                        break;

                    //Rename all images
                    case MenuEnum.Rename:

                        Console.Clear();

                        Console.WriteLine($"{Constant.userMessageForRename}");

                        string userPictureName = Console.ReadLine();

                        Task.Factory.StartNew(() => Editor.RenameImages(token, userPictureName));

                        Constant.CancellationMessage(cancelationToken);

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
    }
}