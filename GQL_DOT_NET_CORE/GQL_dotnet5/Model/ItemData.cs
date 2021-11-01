using GQL_dotnet5.GraphQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL_dotnet5.Model
{
    public record AddItemPayload(ItemData item);
    public record AddItemInput(string title, string description, bool done, int listId);
    public record AddListPayload(ItemList list); 
    public record AddListInput(string name);
    public class ItemData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public int ListId { get; set; }
        public virtual ItemList ItemList { get; set; }
    }
    public class ItemList
    {
        public ItemList()
        {
            ItemDatas = new HashSet<ItemData>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ItemData> ItemDatas { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public virtual DbSet<ItemData> Items { get; set; }
        public virtual DbSet<ItemList> Lists { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                    .WithMany(p => p.ItemDatas)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ItemData_ItemList");
            });
        }
    }
}
