using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());

            var deleted = userService.Delete(2).Result;

            var users = userService.GetAll().Result;

            foreach (var user in users)
            {
                Console.WriteLine(user.Username);
            }

            Console.WriteLine(deleted);
        }

    }
}
