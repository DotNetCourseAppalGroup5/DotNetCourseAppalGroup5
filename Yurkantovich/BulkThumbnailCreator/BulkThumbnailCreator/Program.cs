using System.Threading.Tasks;

namespace BulkThumbnailCreator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ManagmentApp managment = new ManagmentApp();
            ManagmentPicture managmentPicture = new ManagmentPicture();
            managmentPicture.CreateDirectoryForPicture();
            await managment.RunAplicationAsync();
        }
    }
}
