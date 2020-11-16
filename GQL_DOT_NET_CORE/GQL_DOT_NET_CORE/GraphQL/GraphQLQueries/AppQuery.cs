using GQL_DOT_NET_CORE.Contracts;
using GQL_DOT_NET_CORE.GraphQL.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.GraphQL.GraphQLQueries
{
    /// <summary>
    /// https://graphql-dotnet.github.io/docs/getting-started/schema-types/
    /// </summary>
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field<ListGraphType<OwnerType>>(
                "owners",
                resolve: context => repository.GetAll()
            );
        }
    }
}
