using GraphQL.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_client.Consumer
{
    public class OwnerConsumer
    {
        private readonly IGraphQLClient _graphQLClient;
        public OwnerConsumer(IGraphQLClient graphQLClient)
        {
            _graphQLClient = graphQLClient;
        }
    }
}
