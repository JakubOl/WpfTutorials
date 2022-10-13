using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();

            options.UseSqlServer("Server=LTPOL367;Database=SimpleTrader;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SimpleTraderDbContext(options.Options);  
        }
    }
}
