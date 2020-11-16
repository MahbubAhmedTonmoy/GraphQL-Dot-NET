using GQL_DOT_NET_CORE.Contracts;
using GQL_DOT_NET_CORE.Entities;
using GQL_DOT_NET_CORE.GraphQL.GraphQLTypes;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_DOT_NET_CORE.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOwnerRepository repository)
        {
            Field<OwnerType>(
                "createOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner"}),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    return repository.CreateOwner(owner);
                });

            Field<OwnerType>(
                "updateOwner",
                arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" },
                     new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    var dbOwner = repository.GetById(ownerId);
                    if (dbOwner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                        return null;
                    }
                    return repository.UpdateOwner(dbOwner, owner);
                });

            Field<StringGraphType>(
                "deleteOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    if (ownerId == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                        return null;
                    }
                    repository.Deleteowner(ownerId);
                    return $"The owner with the id: {ownerId} has been successfully deleted from db.";
                });
        }
    }
}
