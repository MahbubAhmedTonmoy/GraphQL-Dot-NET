using GQL_dotnet5.Model;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GQL_dotnet5.GraphQL
{
    //public class ItemType : ObjectType<ItemData>
    //{
    //    // since we are inheriting from objtype we need to override the functionality
    //    protected override void Configure(IObjectTypeDescriptor<ItemData> descriptor)
    //    {
    //        descriptor.Description("Used to define todo item for a specific list");

    //        descriptor.Field(x => x.ItemList)
    //                  .ResolveWith<Resolvers>(p => p.GetList(default!, default!))
    //                  .UseDbContext<AppDbContext>()
    //                  .Description("This is the list that the item belongs to");
    //    }

    //    private class Resolvers
    //    {
    //        public ItemList GetList(ItemData item, [ScopedService] AppDbContext context)
    //        {
    //            return context.Lists.FirstOrDefault(x => x.Id == item.ListId);
    //        }
    //    }
    //}
    //public class ListType : ObjectType<ItemList>
    //{
    //    // since we are inheriting from objtype we need to override the functionality
    //    protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
    //    {
    //        descriptor.Description("Used to group the do list item into groups");

    //        descriptor.Field(x => x.ItemDatas).Ignore();

    //        descriptor.Field(x => x.ItemDatas)
    //                    .ResolveWith<Resolvers>(p => p.GetItems(default!, default!))
    //                    .UseDbContext<AppDbContext>()
    //                    .Description("This is the list of to do item available for this list");
    //    }

    //    private class Resolvers
    //    {
    //        public IQueryable<ItemData> GetItems(ItemList list, [ScopedService] AppDbContext context)
    //        {
    //            return context.Items.Where(x => x.ListId == list.Id);
    //        }
    //    }
    //}
}
