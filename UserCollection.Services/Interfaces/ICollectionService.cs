﻿using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ICollectionService
    {
        public Task AddCollectionAsync(CollectionModel collection);

        public Task DeleteCollectionAsync(int id);

        public Task<CollectionModel> GetCollectionAsync(int id);

        public Task<IEnumerable<CollectionModel>> GetAllCollectionsAsync();

        public Task UpdateCollectionAsync(CollectionModel collection);

        public Task<IEnumerable<CollectionModel>> GetUserCollections(string userId);

        public Task<IEnumerable<CollectionModel>> GetFiveBiggestCollectionsAsync();

        public Task<CollectionPageViewModel> GetPageOfCollectionForUser(int pageSize, int pageNumber);

        public Task<CollectionPageViewModel> GetPageOfCollectionForAdmin(int pageSize, int pageNumber);
    }
}
