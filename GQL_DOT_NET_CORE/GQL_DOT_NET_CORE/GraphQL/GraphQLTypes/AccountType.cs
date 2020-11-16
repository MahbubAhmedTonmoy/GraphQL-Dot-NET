using GQL_DOT_NET_CORE.Entities;
using GraphQL.Instrumentation;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.GraphQL.GraphQLTypes
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(i => i.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(i => i.Description).Description("Description property from the account object.");
            Field(i => i.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field<AccountTypeEnumType>("Type", "Enumeration for the account type object.");
        }
    }
}
