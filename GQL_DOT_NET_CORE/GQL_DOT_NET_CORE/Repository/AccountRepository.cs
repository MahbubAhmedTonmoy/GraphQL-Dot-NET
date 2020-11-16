﻿using GQL_DOT_NET_CORE.Contracts;
using GQL_DOT_NET_CORE.Entities;
using GQL_DOT_NET_CORE.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Account> GetAccountById(Guid ownerId)
        {
            var accounts = _context.Accounts.Where(i => i.OwnerId == ownerId).ToList();
            return accounts;
        }
    }
}
