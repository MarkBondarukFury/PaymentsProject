using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var users = ctx.Users.ToList();

                foreach (var user in users)
                    Console.WriteLine(user.Email);

            }
        }
    }
}
