using GQL_DOT_NET_CORE.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.GraphQL.GraphQLTypes
{
    public class OwnerInputType : InputObjectGraphType
    {
        /// <summary>
        /// 
        /// </summary>
        public OwnerInputType()
        {
            Name = "ownerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("address");
        }
    }
}

/*
 mutation($owner: ownerInput!) {
  createOwner(owner: $owner) {
    id,
    name,
    address
  }
}

    {
  "owner": {
  "name": "new name 2",
  "address": "new address 2"
}
}
*/

/*
 mutation($owner: ownerInput!, $ownerId: ID!) {
    updateOwner(owner: $owner, ownerId: $ownerId) {
    id,
    name,
    address
    }
}

{
  "owner": {
  "name": "new name 2 update",
  "address": "new address 2 update"
  },
  "ownerId": "348F7730-F326-4343-B669-072FEA9BAF1A"
}
 */


/*

 mutation($ownerId: ID!) {
deleteOwner(ownerId: $ownerId) 
}
{

"ownerId": "348F7730-F326-4343-B669-072FEA9BAF1A"
}


 */
