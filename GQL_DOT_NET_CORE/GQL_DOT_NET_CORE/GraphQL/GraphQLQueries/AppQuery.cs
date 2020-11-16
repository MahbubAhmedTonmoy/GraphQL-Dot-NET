using GQL_DOT_NET_CORE.Contracts;
using GQL_DOT_NET_CORE.GraphQL.GraphQLTypes;
using GraphQL;
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
        public AppQuery(IOwnerRepository repository, IAccountRepository accountRepository)
        {
            Field<ListGraphType<OwnerType>>(
                "owners",
                resolve: context => repository.GetAll()
            );
            Field<OwnerType>(
                "owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId"}),
                resolve: context => {
                    Guid id;
                    if(!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for guid"));
                        return null;
                    }
                    return repository.GetById(id);
                }
            );
            Field<ListGraphType<AccountType>>(
                "account",
                resolve: context => accountRepository.GetAll()
            );
        }
    }
}
