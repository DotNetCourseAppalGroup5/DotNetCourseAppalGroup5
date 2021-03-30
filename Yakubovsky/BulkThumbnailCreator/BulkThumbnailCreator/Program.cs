using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using BulkThumbnailCreator.Properties;

namespace BulkThumbnailCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            FileExtension fileExtension;
            Finder finder = new Finder();
            MenuAction action;
            
            bool processRun = true;
            
            while (processRun)
            {
                Menu();
                
                Enum.TryParse(Console.ReadLine().ToLower(), out action);
                Console.Clear();

                switch (action)
                {
                    case MenuAction.resize:
                    {
                        fileExtension = ChooseExtension();
                        Task.Factory.StartNew(() => finder.ResizeImages(fileExtension)).Wait();
                        break;
                    }
                    case MenuAction.rename:
                    {
                        Console.Write(Constansts.PictureProcess.PictureName);
                        string newNameForFiles = Console.ReadLine();
                        
                        fileExtension = ChooseExtension();
                        Task.Factory.StartNew(() => finder.RenameImages(newNameForFiles,fileExtension)).Wait();
                        break;
                    }
                    case MenuAction.exit:
                    {
                        processRun = false;
                        Console.WriteLine(Constansts.UserNotifications.NotifyExit);
                        Thread.Sleep(3000);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine(Constansts.ErrorMessages.InputError);
                        Thread.Sleep(1500);
                        break;
                    }
                }
                Console.Clear();
            }
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Constansts.MainMenu.PointResize);
            Console.WriteLine(Constansts.MainMenu.PointRename);
            Console.WriteLine(Constansts.MainMenu.PointExit);
            Console.Write(Constansts.MainMenu.PointOperationChoice);
            Console.ResetColor();
        }
        
        static void ShowFileExtension()
        {
            Console.WriteLine($"1){FileExtension.jpeg}");
            Console.WriteLine($"2){FileExtension.jpg}");
            Console.WriteLine($"3){FileExtension.png}");
            Console.WriteLine($"4){FileExtension.ai}");
            Console.WriteLine($"5){FileExtension.bmp}");
            Console.WriteLine($"6){FileExtension.eps}");
            Console.WriteLine($"7){FileExtension.pdf}");
            Console.WriteLine($"8){FileExtension.psd}");
            Console.WriteLine($"9){FileExtension.tiff}");
        }

        static FileExtension ChooseExtension()
        {
            ShowFileExtension();
            
            Console.Write(Constansts.PictureProcess.PictureExtensionChoice);
            char choice = Console.ReadKey().KeyChar;
            
            switch (choice)
            {
                case '1' : return FileExtension.jpeg;
                case '2' : return FileExtension.jpg;
                case '3' : return FileExtension.png;
                case '4' : return FileExtension.ai;
                case '5' : return FileExtension.bmp;
                case '6' : return FileExtension.eps;
                case '7' : return FileExtension.pdf;
                case '8' : return FileExtension.psd;
                case '9' : return FileExtension.tiff;
                default: throw new ArgumentException();
            }
        }
    }
}