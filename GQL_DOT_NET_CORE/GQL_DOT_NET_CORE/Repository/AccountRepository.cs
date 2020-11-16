using GQL_DOT_NET_CORE.Contracts;
using GQL_DOT_NET_CORE.Entities;
using GQL_DOT_NET_CORE.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;
        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }
        public IEnumerable<Account> GetAccountById(Guid ownerId)
        {
            var accounts = _context.Accounts.Where(i => i.OwnerId == ownerId).ToList();
            return accounts;
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(i => ownerIds.Contains(i.OwnerId)).ToListAsync();
            var LOOKUP = accounts.ToLookup(x => x.OwnerId);
            return LOOKUP;
        }
    }
}
