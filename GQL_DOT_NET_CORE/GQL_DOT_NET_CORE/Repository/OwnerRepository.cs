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

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public void Deleteowner(Guid id)
        {
            var owner = _context.Owners.FirstOrDefault(x => x.Id == id);
            _context.Remove(owner);
            _context.SaveChanges();
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }

        public Owner GetById(Guid id)
        {
            var owner = _context.Owners.FirstOrDefault(x => x.Id == id);
            return owner;
        }

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            _context.SaveChanges();
            return dbOwner;
        }
    }
}
