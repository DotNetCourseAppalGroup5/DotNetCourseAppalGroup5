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
            string filesPath = ConfigurationManager.AppSettings["filePath"];
            string newFilesPath = ConfigurationManager.AppSettings["newFilePath"];

            if (!IsDirectoryExists(filesPath)) return;
            DirectoryInfo directoryInfo = new DirectoryInfo(filesPath);

            IsDirectoryExists(newFilesPath);

            FileInfo[] files = directoryInfo.GetFiles();
            if (!IsFileExists(files)) return;  

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            do
            {
                ShowMenu();
                MenuPoints choice = InputMenu();
                Console.Clear();

                if (choice == MenuPoints.Exit) break;

                Task task;
                bool isCanceled = false;

                switch (choice)
                {
                    case MenuPoints.Resize:
                        {
                            int width = GetWidth();
                            int heigth = GetHeigth();

                            task = new Task(() =>
                            { 
                                PhotoManager.ResizeImages(filesPath, newFilesPath, width, heigth, token, out isCanceled);
                            });

                            task.Start();
                            CancelOperation(cancelTokenSource);

                            break;
                        }
                    case MenuPoints.Rename:
                        {
                            string newFilesName = GetNewFilesName();

                            task = new Task(() =>
                            {
                                PhotoManager.RenameImages(files, newFilesName, token, out isCanceled);
                            });

                            task.Start();
                            CancelOperation(cancelTokenSource);

                            break;
                        }
                    default:
                        {
                            Console.WriteLine(Constants.unknownCommand);
                            break;
                        }
                }

                if (!isCanceled) Console.WriteLine(Constants.successfullOperation);
                else Console.WriteLine(Constants.canceledOperation);
                
                Console.WriteLine(Constants.anyKeyToContinue);
                Console.ReadKey();
                Console.Clear();

            } while (true);

            Console.WriteLine(Constants.programEnd);
            Console.ReadKey();
        }

        static bool IsDirectoryExists(string filesPath)
        {
            if (!Directory.Exists(filesPath))
            {
                Console.WriteLine("Specified directory doesn't exists!");
                Console.WriteLine("Creating new directory...");
                Console.WriteLine(filesPath);
                Directory.CreateDirectory(filesPath);
                Console.ReadKey();
                return false;
            }
            else return true;
        }

        static bool IsFileExists(FileInfo[] files)
        {
            if (files.Length != 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Directory is empty!");
                Console.WriteLine("Please add some files");
                Console.ReadKey();
                return false;
            }
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