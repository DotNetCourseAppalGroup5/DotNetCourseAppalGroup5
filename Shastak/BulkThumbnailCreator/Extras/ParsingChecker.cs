using System;
using System.Configuration;

namespace BulkThumbnailCreator.Extras
{
    public static class ParsingChecker
    {
        public static ushort SetPixels()
        {
            bool isStarted = true;
            ushort pixels;

            ushort minPixelsPerDimension = ushort.Parse(ConfigurationManager.AppSettings.Get("minPixelsPerDimension"));
            ushort maxPixelsPerDimension = ushort.Parse(ConfigurationManager.AppSettings.Get("maxPixelsPerDimension"));

            do
            {
                string userInput = Console.ReadLine().Trim();
                bool validationCheck = ushort.TryParse(userInput, out pixels);

                if (!validationCheck)
                    TextColorizer.WriteTextInColor("\nInvalid input, please try again: ", ConsoleColor.Red, false);
                else if (pixels < minPixelsPerDimension || pixels > maxPixelsPerDimension)
                    TextColorizer.WriteTextInColor("\nPlease enter valid dimension size (from 1 to 4096): ", ConsoleColor.Red, false);
                else
                    isStarted = false;
            }
            while (isStarted);

            return pixels;
        }
    }
}
