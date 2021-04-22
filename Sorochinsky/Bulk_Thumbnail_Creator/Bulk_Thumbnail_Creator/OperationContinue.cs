using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Thumbnail_Creator
{
    public class UserManipulation
    {
        public void ContinueProgram()
        {
            Console.WriteLine(Constants.anyKeyToContinue);
            Console.ReadKey();
            Console.Clear();
        }

        public void FinishProgram()
        {
            Console.WriteLine(Constants.programEnd);
            Console.ReadKey();
        }
    }
}
