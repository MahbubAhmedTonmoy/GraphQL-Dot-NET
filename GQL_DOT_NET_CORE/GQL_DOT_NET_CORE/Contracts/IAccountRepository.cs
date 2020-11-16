﻿using GQL_DOT_NET_CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccountById(Guid ownerId);
    }
}
