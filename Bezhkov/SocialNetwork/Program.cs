using Entity;
using Entity.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StringContex db = new StringContex())
            {
                db.Migrate();
            }

            Console.WriteLine("Готово");
            Console.ReadKey();

        }
    }
}
