using System;
using System.Threading;
using System.Threading.Tasks;

namespace BulkThumbnailCreator
{
    public class ManagmentApp
    {
        public async Task RunAplicationAsync()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            while (!token.IsCancellationRequested)
            {
                ShowCommands();
                await WaitForCommandAsync();

                WorkWithText.ShowInformationMessage("Click [Q] or [q] to close the application. Press any key to continue.");
                char c = Console.ReadKey().KeyChar;
               
                if (c == 'q' || c == 'Q')
                {
                    tokenSource.Cancel();
                    WorkWithText.ShowErrorMessage("Exit application.");
                    return;
                }
            }
        }

        private async Task WaitForCommandAsync()
        {
            int command;
            while (!int.TryParse(Console.ReadLine(), out command))
            {
                WorkWithText.ShowErrorMessage("Command doesn't exist\n");
            }
            await ApplyCommandAsync(command);
        }

        private async Task ApplyCommandAsync(int command)
        {
            ManagmentPicture managment = new ManagmentPicture();
            switch ((Menu)command)
            {
                case Menu.CreateDirectory:
                    managment.CreateDirectoryForPicture();
                    break;
                case Menu.CopyFiles:
                    await managment.CopyFilesInNewFolderAsync();
                    break;
                case Menu.Rename:
                    await managment.RenameFilesAsync();
                    break;
                case Menu.ChangeExtension:
                    await managment.ChangeFilesExtensionAsync();
                    break;
                case Menu.DeleteFiles:
                    await managment.DeleteFileFromFolderAsync();
                    break;
            }
        }

        private void ShowCommands()
        {
            WorkWithText.ShowMessage("\nSELECT ONE OF THE COMMANDS:\n");
            WorkWithText.ShowInformationMessage(
                $"1 - Create the folder to copy images.",
                $"2 - Copy images to the created folder with given width and height.",
                $"3 - Rename all images.",
                $"4 - Change the extension of all images.",
                $"5 - Delete files from folder.");
        }
    }
}
