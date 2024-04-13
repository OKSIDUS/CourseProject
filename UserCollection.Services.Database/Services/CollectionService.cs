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
                collection = CheckCustomField(collection);
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
            var category = await dbContext.Categories
                .Include(i => i.UserCollections)
                .ThenInclude(c => c.Items)
                .ToListAsync();

            var collections = category.SelectMany(c => c.UserCollections).ToList();
            return collections.Select(c => mapper.Map<CollectionModel>(c));
        }

        public async Task<CollectionModel> GetCollectionAsync(int id)
        {
            var collection = await dbContext.Collections.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefaultAsync();
            return mapper.Map<CollectionModel>(collection);
        }

        public async Task<IEnumerable<CollectionModel>> GetFiveBiggestCollectionsAsync()
        {
            var collections = await dbContext.Collections.Include(c => c.Category).OrderByDescending(c => c.Items.Count()).Take(5).ToListAsync();
            return collections.Select(c => mapper.Map<CollectionModel>(c));
        }

        public async Task<IEnumerable<CollectionModel>> GetUserCollections(string userId)
        {
            var collections = await dbContext.Collections.Include(c => c.Category).Where(c => c.UserId == userId).ToListAsync();
            return collections.Select(c => mapper.Map<CollectionModel>(c));
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


        private CollectionModel CheckCustomField(CollectionModel collection)
        {
            collection.CustomBoolFields = NoteCustomFields(collection.CustomBoolFields);
            collection.CustomTextFields = NoteCustomFields(collection.CustomTextFields);
            collection.CustomDateTimeFields = NoteCustomFields(collection.CustomDateTimeFields);
            collection.CustomStringFields = NoteCustomFields(collection.CustomStringFields);
            collection.CustomIntegerFields = NoteCustomFields(collection.CustomIntegerFields);

            return collection;
        }

        private CustomFieldsModel NoteCustomFields(CustomFieldsModel customFields)
        {

            customFields.CustomField1State = !string.IsNullOrEmpty(customFields.CustomField1Name);
            customFields.CustomField1Name = customFields.CustomField1State  ? customFields.CustomField1Name : string.Empty;

            customFields.CustomField2State = !string.IsNullOrEmpty(customFields.CustomField2Name);
            customFields.CustomField2Name = customFields.CustomField2State ? customFields.CustomField2Name : string.Empty;

            customFields.CustomField3State = !string.IsNullOrEmpty(customFields.CustomField3Name);
            customFields.CustomField3Name = customFields.CustomField3State ? customFields.CustomField3Name : string.Empty;

            return customFields;
        }
    }
}
