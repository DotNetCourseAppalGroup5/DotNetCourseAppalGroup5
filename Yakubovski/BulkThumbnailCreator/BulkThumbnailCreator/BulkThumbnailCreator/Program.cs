using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using BulkThumbnailCreator.Properties;

namespace BulkThumbnailCreator
{
    internal class Program
    {
        public delegate void ShowMenu();
        
        public static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            
            Finder finder = new Finder();
            ShowMenu showMenu = new ShowMenu(Menu);
            bool processRun = true;
            
            while (processRun)
            {
                showMenu?.Invoke();
                MenuAction action;
                Enum.TryParse(Console.ReadLine().ToLower(), out action);
                Console.Clear();

                switch (action)
                {
                    case MenuAction.resize:
                        Task.Factory.StartNew(() => finder.ResizeImages()).Wait();
                        break;
                    case MenuAction.rename:
                        Task.Factory.StartNew(() => finder.RenameImages()).Wait();
                        break;
                    case MenuAction.exit:
                        processRun = false;
                        Thread.Sleep(3000);
                        Console.WriteLine(Constansts.UserNotifications.NotifyExit);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1) Resize images.");
            Console.WriteLine("2) Rename images.");
            Console.WriteLine("3) Exit.");
            Console.Write("Enter name of operation or point of operation: ");
            Console.ResetColor();
        }
    }
}