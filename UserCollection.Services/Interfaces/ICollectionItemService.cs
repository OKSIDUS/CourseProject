using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ICollectionItemService
    {
        public Task AddItem(ItemModel item);

        public Task UpdateItem(ItemModel item);

        public Task DeleteItem(int id);

        public Task<ItemModel> GetItemById(int id);

        public Task<IEnumerable<ItemModel>> GetAll();


    }
}
