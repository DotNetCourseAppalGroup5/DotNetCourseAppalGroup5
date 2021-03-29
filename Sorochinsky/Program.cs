using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Bulk_Thumbnail_Creator
{
    public class Program
    {
        static void Main()
        {
            string filesPath = @"E:\newphot";

            DirectoryInfo directoryInfo = new DirectoryInfo(filesPath);
            FileInfo[] files = directoryInfo.GetFiles();

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            do
            {
                ShowMenu();
                MenuPoints choice = InputMenu();
                Console.Clear();

                if (choice == MenuPoints.Exit) break;

                Task task;

                switch (choice)
                {
                    case MenuPoints.Resize:
                        {
                            task = new Task(() =>
                            {
                                ResizePictures(filesPath, token);
                            });
                            task.Start();
                            CancelOperation(cancelTokenSource);
                            task.Wait();
                            break;
                        }
                    case MenuPoints.Rename:
                        {
                            task = new Task(() =>
                            {
                                RenamePictures(files, token);
                            });
                            task.Start();
                            CancelOperation(cancelTokenSource);
                            task.Wait();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong command!");
                            break;
                        }
                }

                Console.Clear();
            } while (true);

            Console.WriteLine("Input any key to exit...");
            Console.ReadKey();
        }

        static void ShowMenu()
        {
            Console.WriteLine("1 - Resize");
            Console.WriteLine("2 - Rename");
            Console.WriteLine("3 - Exit");
        }

        static MenuPoints InputMenu()
        {
            Console.Write("Command: ");
            int choice = int.Parse(Console.ReadLine());
            return (MenuPoints)choice;
        }

        static void RenamePictures(FileInfo[] files, CancellationToken token)
        {
            Console.WriteLine("---Rename---");

            bool isCanceled = false;

            string newFilesName;
            Console.WriteLine("Input name for all files");
            newFilesName = Console.ReadLine();

            PhotoManager.RenameImages(files, newFilesName, token, out isCanceled);

            if (isCanceled)
            {
                Console.WriteLine("Operation was canceled!");
            }
            else
            {
                Console.WriteLine("Operation was completed!");
            }
        }

        static void ResizePictures(string filePath, CancellationToken token)
        {
            Console.WriteLine("---Resize---");

            bool isCanceled = false;

            Console.WriteLine("Please input new image width");
            int width = GetNumber();

            Console.WriteLine("Please input new image heigth");
            int heigth = GetNumber();

            PhotoManager.ResizeImages(filePath, width, heigth, token, out isCanceled);

            if(isCanceled)
            {
                Console.WriteLine("Operation was canceled!");
            }
            else
            {
                Console.WriteLine("Operation was completed!");
            }
        }

        static int GetNumber()
        {
            do
            {
                Console.Write("Value: ");
                int value;
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
            } while (true);
        }

        static void CancelOperation(CancellationTokenSource tokenSource)
        {
            Console.WriteLine("Inout E to exit");
            string userInput = Console.ReadLine().Trim().ToUpper();

            if (userInput == "E")
            {
                tokenSource.Cancel();
            }
        }
    }
}
