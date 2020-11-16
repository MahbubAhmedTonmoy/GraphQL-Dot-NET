using GQL_DOT_NET_CORE.GraphQL.GraphQLQueries;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}
