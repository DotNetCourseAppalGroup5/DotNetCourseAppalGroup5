using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace Bulk_Thumbnail_Creator
    {
    public class Program
    {
        static void Main()
        {
            //
            string filesPath = ConfigurationManager.AppSettings["filePath"];
            string newFilesPath = ConfigurationManager.AppSettings["newFilePath"];

            FileChecker fileChecker = new FileChecker();
            FileInfo[] files = fileChecker.IsAvailableWorkingWithFiles(filesPath, newFilesPath);

            if (files == null) return;
            
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            PhotoManager manager = new PhotoManager();
            UserManipulation userManipulation = new UserManipulation();

            do
            {
                ShowMenu();
                MenuPoints choice = InputMenu();
                Console.Clear();

                if (choice == MenuPoints.Exit) break;

                Task task;
                bool isCanceled = false;
                bool hasResult = false;

                switch (choice)
                {
                    case MenuPoints.Resize:
                        {
                            hasResult = true;

                            int width = GetWidth();
                            int heigth = GetHeigth();

                            task = new Task(() =>
                            {
                                manager.ResizeImages(filesPath, newFilesPath, width, heigth, token, out isCanceled);
                            });

                            task.Start();
                            CancelOperation(cancelTokenSource);
                            task.Wait();

                            break;
                        }
                    case MenuPoints.Rename:
                        {
                            hasResult = true;
                            string newFilesName = GetNewFilesName();

                            task = new Task(() =>
                            {
                                manager.RenameImages(files, newFilesName, token, out isCanceled);
                            });

                            task.Start();
                            CancelOperation(cancelTokenSource);
                            task.Wait();

                            break;
                        }
                    default:
                        {
                            Console.WriteLine(Constants.unknownCommand);
                            break;
                        }
                }

                if(hasResult)
                {
                    if (isCanceled) Console.WriteLine(Constants.canceledOperation);
                    else Console.WriteLine(Constants.successfullOperation);
                }

                userManipulation.ContinueProgram();

            } while (true);

            userManipulation.FinishProgram();        
        }

        static void ShowMenu()
        {
            Console.WriteLine(Constants.mainMenu);
        }

        static MenuPoints InputMenu()
        {
            return (MenuPoints)GetNumber();
        }

        static string GetNewFilesName()
        {
            Console.WriteLine("Input name for all files");
            string newFilesName = Console.ReadLine();
            return newFilesName;
        }

        static int GetHeigth()
        {
            Console.Write("Heigth: ");
            return GetNumber();
        }

        static int GetWidth()
        {
            Console.Write("Widt: ");
            return GetNumber();
        }

        static int GetNumber()
        {
            do
            {
                int value;
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
            } while (true);
        }

        static void CancelOperation(CancellationTokenSource tokenSource)
        {
            Console.WriteLine("Input E to exit");
            string userInput = Console.ReadLine().Trim().ToUpper();

            if (userInput.Equals("E"))
            {
                tokenSource.Cancel();
            }
        }
    }
}