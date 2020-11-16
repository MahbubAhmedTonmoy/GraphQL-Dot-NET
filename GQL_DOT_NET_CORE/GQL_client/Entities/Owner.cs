using System;
using System.Collections.Generic;

namespace GQL_client.Entities
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
