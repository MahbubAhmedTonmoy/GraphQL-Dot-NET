using GQL_dotnet5.Model;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_dotnet5.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetItems([ScopedService]AppDbContext context)
        {
            return context.Items;
        }
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetLists([ScopedService] AppDbContext context)
        {
            return context.Lists;
        }
    }

    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] AppDbContext context)
        {
            var list = new ItemList
            {
                Name = input.name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync();

            return new AddListPayload(list);
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] AppDbContext context)
        {
            var item = new ItemData
            {
                Description = input.description,
                Done = input.done,
                Title = input.title,
                ListId = input.listId
            };

            context.Items.Add(item);
            await context.SaveChangesAsync();

            return new AddItemPayload(item);
        }
    }

    public class Subscription
    {
        [Subscribe]
        [Topic]
        public ItemList OnListAdded([EventMessage] ItemList list) => list;
    }
}
