using GQL_DOT_NET_CORE.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner GetById(Guid id);
        Owner CreateOwner(Owner owner);
        Owner UpdateOwner(Owner dbOwner, Owner owner);
        void Deleteowner(Guid id);
    }
}
