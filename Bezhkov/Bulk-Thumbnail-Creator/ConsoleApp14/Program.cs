using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        #region
        //Homework information
        private static void Info()
        {
            Console.WriteLine(new string('-', 119));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t \t \t \t \t Homework Bulk Thumbnail  Creator");
            Console.WriteLine("\t \t \t \t \t         By Vadim Bezhkov");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string('-', 120));
        }

        //Result operation Rename
        private static void ResultRenameInfo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All image rename!!!!");
            Console.WriteLine();
            Console.ResetColor();
            ActionMenu();
        }

        //Result operation Resize
        private static void ResultInfo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All image resize!!!!!!!!");
            Console.WriteLine("press any button to continue");
            Console.ResetColor();
        }

        // Text menu info
        private static void ActionMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press enter 1 - Resize all image");
            Console.WriteLine("Press enter 2 - Rename all image");
            Console.WriteLine("Press enter 3 - Exit");
        }

        //Checking and setting the image size
        private static void ResizeParametrs(out int width, out int height)
        {
            Console.WriteLine("Enter width");
            int.TryParse(Console.ReadLine(), out width);

            Console.WriteLine("Enter height");
            int.TryParse(Console.ReadLine(), out height);
        }

        // Incorrect choice
        private static void Default()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Error enter number 1 or 2 or 3");
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void Decoration()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 119));
            Console.WriteLine("Task canceled");
            Console.WriteLine(new string('-', 119));
        }
        #endregion
        static void Main(string[] args)
        {
            Images image = new Images(true);

            image.EventActionMenu += ActionMenu;
            image.EventResultInfo += ResultInfo;
            image.EventResultRenameInfo += ResultRenameInfo;

            Info();

            while (true)
            {
                ActionMenu();
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                CancellationToken token = cancelTokenSource.Token;

                Operation op;
                Enum.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    // Choise resize my images
                    case Operation.Resize:
                        {
                            ResizeParametrs(out int width, out int height);
                            image.ResizeParametrs(width, height);

                            Task task = new Task(() => image.Resize(token));
                            task.Start();

                            Console.WriteLine("Enter Y to cancel the operation:");
                            string s = Console.ReadLine();
                            if (s == "Y" || s == "y")
                            {
                                cancelTokenSource.Cancel();
                                Decoration();
                            }
                        }

                        break;
                    //Choise rename my images
                    case Operation.Rename:
                        {
                            Console.WriteLine("Enter new name");
                            image.Name = Console.ReadLine();

                            Task task2 = new Task(image.Rename, image.Name);
                            task2.Start();
                        }

                        break;
                    //exit this programm
                    case Operation.Exit:
                        Environment.Exit(0);

                        break;
                    default:
                        Default();
                        break;
                }
            }
        }
    }
}