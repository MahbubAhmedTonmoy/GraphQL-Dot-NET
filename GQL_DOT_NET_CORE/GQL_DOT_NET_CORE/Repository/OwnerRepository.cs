using GQL_DOT_NET_CORE.Contracts;
using GQL_DOT_NET_CORE.Entities;
using GQL_DOT_NET_CORE.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;
        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }
    }
}
