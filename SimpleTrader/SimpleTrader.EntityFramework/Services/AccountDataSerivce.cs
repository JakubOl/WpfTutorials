using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services
{
    public class AccountDataSerivce : IDataService<Account>
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataSerivce(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts.Include(a => a.AssetTransactions).ToListAsync();

                return entities;
            }
        }

        public async Task<Account> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.Include(a => a.AssetTransactions).FirstOrDefaultAsync(e => e.Id == id);

                return entity;
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        } 
    }
}
