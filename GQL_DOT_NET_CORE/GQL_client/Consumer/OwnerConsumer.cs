using GQL_client.Entities;
using GQL_client.GraphQL.GraphQLTypes;
using GraphQL;
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

        public async Task<List<Owner>> GetAllOwners()
        {
            var query = new GraphQLRequest
            {
                Query = @"query ownersQuery{
                              owners{
                                id,
                                name,
                                address,
                                 accounts{
                                  id,
                                  description,
                                  ownerId,
                                  type
                                }
                              }
                            }"
            };
            var response = await _graphQLClient.SendQueryAsync<ResponseOwnerCollectionType>(query);
            return response.Data.Owners;
        }

        public async Task<Owner> GetOwnerById(Guid id)
        {
            var query = new GraphQLRequest
            {
                Query = @" query ownerQuery($ownerID: ID!) {
                          owner(ownerId: $ownerID) {
                            id
                            name
                            address
                            accounts {
                              id
                              type
                              description
                            }
                          }
                        }",
                Variables = new { ownerId = id }
            };
            var response = await _graphQLClient.SendMutationAsync<ResponseOwnerType>(query);

            return response.Data.Owner;
        }
        public async Task<Owner> CreateOwner(OwnerInput ownerInput)
        {
            var query = new GraphQLRequest
            {
                Query = @"mutation($owner: ownerInput!) {
                          createOwner(owner: $owner) {
                            id,
                            name,
                            address
                          }
                        }",
                Variables = new {owner = ownerInput}
            };

            var response = await _graphQLClient.SendMutationAsync<ResponseOwnerType>(query);

            return response.Data.Owner;
        }
        public async Task<Owner> UpdateOwner(Guid id, OwnerInput updatedData)
        {
            var query = new GraphQLRequest
            {
                Query = @"mutation($owner: ownerInput!, $ownerId: ID!) {
                            updateOwner(owner: $owner, ownerId: $ownerId) {
                            id,
                            name,
                            address
                            }
                         }
                       ",
                Variables = new { owner = updatedData, ownerId = id }
            };
            var response = await _graphQLClient.SendMutationAsync<ResponseOwnerType>(query);

            return response.Data.Owner;
        }

        public async Task<Owner> DeleteOwner(Guid Id)
        {
            var query = new GraphQLRequest
            {
                Query = @" mutation($ownerId: ID!) {
                                deleteOwner(ownerId: $ownerId) 
                            }",
                Variables = new { ownerId = Id }
            };
            var response = await _graphQLClient.SendMutationAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
        }
    }
    
    public class ResponseOwnerCollectionType
    {
        public List<Owner> Owners { get; set; }
    }
    public class ResponseOwnerType
    {
        public Owner Owner { get; set; }
    }
}
