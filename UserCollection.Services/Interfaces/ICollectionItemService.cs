using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ICollectionItemService
    {
        public Task AddItemAsync(ItemModel item);

        public Task UpdateItemAsync(ItemModel item);

        public Task DeleteItemAsync(int id);

        public Task<ItemModel> GetItemByIdAsync(int id);

        public Task<IEnumerable<ItemModel>> GetAllAsync();

        public Task<IEnumerable<ItemModel>> FullTextSearch(string query);


    }
}
