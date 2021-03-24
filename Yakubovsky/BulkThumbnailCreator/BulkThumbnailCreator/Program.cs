using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

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
                char choice = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (choice)
                {
                    case '1':
                        Task.Factory.StartNew(() => finder.ResizeImages()).Wait();
                        
                        break;
                    case '2':
                        Task.Factory.StartNew(() => finder.RenameImages()).Wait();
                        
                        break;
                    case '3':
                        processRun = false;
                        Thread.Sleep(3000);
                        Console.WriteLine("\t\t\tSee you again!");
                        
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
            Console.Write("Enter point: ");
            Console.ResetColor();
        }
    }
}