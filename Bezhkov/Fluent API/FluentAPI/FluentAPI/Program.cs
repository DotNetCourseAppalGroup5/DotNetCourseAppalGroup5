using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class Program
    {
        static void Main(string[] args)
        {
         
                UserRepository us = new UserRepository(new StringConnection());

                Users us1 = new Users
                {
                    LastName = "Vadim",
                    FirstName = "Bezhkov",
                    Email = "vadimbezhkov3112@gmail.com",
                    Login = "Vadim",
                    Password = "123",
                    SecondName = "Alexandrovich",
                    TimeRegistration = DateTime.Now
                };
                Users us2 = new Users
                {
                    LastName = "Pavel",
                    FirstName = "Kononovich",
                    Email = "kononsoft@gmail.com",
                    Login = "imkonon",
                    Password = "12345",
                    SecondName = "Alexandrovich",
                    TimeRegistration = DateTime.Now
                };
                us.Create(us1);
                us.Create(us2);
               
         
            Console.WriteLine("Ready");

            Console.ReadKey();
        }
    }
}
