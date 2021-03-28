using System;

namespace BulkThumbnailCreator.Extras
{
    public static class DisplayProgress
    {
        // constant that shows which position from left side the cursor will be on
        public const int CursorOffset = 27;

        public static void Show(int total, int amountOutOfTotal, ref int lengthPrevious)
        {
            double percentage = Math.Round((double)amountOutOfTotal / (double)total * 100, 2);

            string progress = $"Processed {amountOutOfTotal} files out of {total} ({percentage}%).";
            int length = progress.Length;

            Console.CursorTop--;
            Console.CursorLeft = 0;
            Console.Write(progress);

            int diff = lengthPrevious - length;

            // handling cases when current text is shorter than previous and unnessesary chars are shown
            if (length < lengthPrevious)
            {
                for (int i = 1; i < (diff + 1); i++)
                {
                    Console.Write(" ");
                }

                Console.CursorLeft -= diff;
            }

            Console.CursorTop++;
            lengthPrevious = length;
        }
    }
}
