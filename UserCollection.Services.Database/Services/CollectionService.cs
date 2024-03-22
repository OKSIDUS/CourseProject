using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using UserCollection.Services.Database.Entities;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Database.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IMapper mapper;

        public CollectionService(ApplicationDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddCollectionAsync(CollectionModel collection)
        {
            if (collection is not null)
            {
                var collectionEntity = mapper.Map<CollectionEntity>(collection);
                await dbContext.Collections.AddAsync(collectionEntity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCollectionAsync(int id)
        {
            var collection = await dbContext.Collections.Where(c =>c.Id == id).FirstOrDefaultAsync();

            if (collection is not null)
            {
                dbContext.Collections.Remove(collection);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CollectionModel>> GetAllCollectionsAsync()
        {
            var collections = await dbContext.Collections.Include(c => c.Items).ToListAsync();
            return collections.Select(c => mapper.Map<CollectionModel>(c));
        }

        public async Task<CollectionModel> GetCollectionAsync(int id)
        {
            var collection = await dbContext.Collections.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefaultAsync();
            return mapper.Map<CollectionModel>(collection);
        }

        public async Task UpdateCollectionAsync(CollectionModel collection)
        {
            var collectionEntity = await dbContext.Collections.Where(c => c.Id == collection.Id).FirstOrDefaultAsync();
            if (collectionEntity is not null)
            {
                mapper.Map(collection, collectionEntity);
                dbContext.Collections.Update(collectionEntity);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
