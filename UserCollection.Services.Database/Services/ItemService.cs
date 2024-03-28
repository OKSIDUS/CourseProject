using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var collections = await dbContext.Items
                .Where(x => EF.Functions.Contains(x.Name, query)).ToListAsync();

            return collections.Select(i => mapper.Map<ItemModel>(i));
        }

        public async Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            var items = await dbContext.Items.ToListAsync();
            return items.Select(i => mapper.Map<ItemModel>(i));
        }

        public async Task<IEnumerable<ItemModel>> GetAllCollectionItemsAsync(int id)
        {
            var items = await dbContext.Items.Where(i => i.CollectionId == id).ToListAsync();
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
