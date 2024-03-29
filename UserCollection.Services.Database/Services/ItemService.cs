using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UserCollection.Services.Database.Entities;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Database.Services
{
    public class ItemService : ICollectionItemService
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IMapper mapper;

        public ItemService(ApplicationDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddItemAsync(ItemModel item)
        {
            if (item is not null)
            {
                var itemEntity = mapper.Map<ItemEntity>(item);
                await dbContext.Items.AddAsync(itemEntity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await dbContext.Items.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (item is not null)
            {
                dbContext.Items.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ItemModel>> FullTextSearch(string query)
        {
            var items = await dbContext.Items.Include(i => i.Collection)
                .Where(x => EF.Functions.Contains(x.Name, query)).ToListAsync();

            //var collectionIds = collections.Select(i => i.CollectionId).ToList();

            var collections = await dbContext.Items.Include(i => i.Collection)
                .Where(c => EF.Functions.Contains(c.Collection.Name, query) ||
                            EF.Functions.Contains(c.Collection.Description, query) ||
                            EF.Functions.Contains(c.Collection.UserName, query))
                .ToListAsync();

            items.AddRange(collections);
            return items.Select(i => mapper.Map<ItemModel>(i));
        }

        public async Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            var items = await dbContext.Items.ToListAsync();
            return items.Select(i => mapper.Map<ItemModel>(i));
        }

        public async Task<IEnumerable<ItemModel>> GetAllCollectionItemsAsync(int id)
        {
            var items = await dbContext.Items.Include(i => i.Collection).Where(i => i.CollectionId == id).ToListAsync();
            return items.Select(i => mapper.Map<ItemModel>(i));
        }

        public async Task<ItemModel> GetItemByIdAsync(int id)
        {
            var item = await dbContext.Items.Include(i => i.Collection).Where(i => i.Id == id).FirstOrDefaultAsync();
            return mapper.Map<ItemModel>(item);
        }

        public async Task UpdateItemAsync(ItemModel item)
        {
            var itemEntity = await dbContext.Items.Where(i => i.Id == item.Id).FirstOrDefaultAsync();
            if (itemEntity is not null)
            {
                mapper.Map(item, itemEntity);
                dbContext.Items.Update(itemEntity);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
