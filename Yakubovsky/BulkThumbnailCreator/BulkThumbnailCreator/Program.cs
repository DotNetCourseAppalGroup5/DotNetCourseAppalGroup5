﻿using System;
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
                        Task.Factory.StartNew(() => finder.ResizeImages(token));
                        CancellationMenu(cancelTokenSource);
                        break;
                    }
                    case MenuAction.rename:
                    {
                        Console.Write(Constansts.PictureProcess.PictureName);
                        string newNameForFiles = Console.ReadLine();

                        Task.Factory.StartNew(() => finder.RenameImages(newNameForFiles, token));
                        CancellationMenu(cancelTokenSource);
                        break;
                    }
                    case MenuAction.exit:
                    {
                        processRun = false;
                        Console.WriteLine(Constansts.UserNotifications.NotifyExit);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine(Constansts.ErrorMessages.InputError);
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

        static void CancellationMenu(CancellationTokenSource cancellationTokenSource)
        {
            Console.WriteLine(Constansts.CancellationRequest.request);
            string request = Console.ReadLine().ToLower();

            if (request == "s")
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}