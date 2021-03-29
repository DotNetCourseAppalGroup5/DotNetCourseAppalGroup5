namespace BulkThumbnailCreator
{
    public static class Constants
    {
        public static string appName = "Bulk Thumbnail Creator";
        public static string appDescription = "This program allows you to resize or rename your images. \n" +
            "All your processed images will be stored in Processed Files folder. \n" +
            "Please make sure you have all needed images in Source Files folder.";

        public static string noFilesInSourceFolder = "Your source folder doesn't contain any files! \n" +
            "Please add some files in the source folder and press any key to continue. \n";
        public static string unrecognizedCommand = "Unrecognized command. Press any key to get back to the main menu..";
        
        public static string sayGoodbyePolitely = "Thank you for using BulkThumbnailCreator. Come back soon!";

        public static string mainMenu = "'1' - Resize images \n'2' - Rename images \n'3' - Exit program";

        public static string operationCompleted = "Operation is completed successfully!";
        public static string operationAborted = "Operation was aborted by";

        public static string loggerTimeNow = "yyyy-MM-dd HH:mm:ss.fffff";
        public static string loggerTimeToday = "yyyy-MM-dd";
    }
}
