using System;

namespace BulkThumbnailCreator.Extras
{
    public static class TextColorizer
    {
        public static void WriteTextInColor(string text, ConsoleColor color, bool isWriteLine = true)
        {
            Console.ForegroundColor = color;

            if (isWriteLine)
                Console.WriteLine(text);
            else
                Console.Write(text);

            Console.ResetColor();
        }
    }
}
