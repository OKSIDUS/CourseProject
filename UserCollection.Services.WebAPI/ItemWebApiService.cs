using System.Net.Http.Json;
using System.Text.Json;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.WebAPI
{
    public class ItemWebApiService : ICollectionItemService
    {
        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://userCollectionWebApi.somee.com"),
        };

        public async Task AddItemAsync(ItemModel item)
        {
            if (item is not null)
            {
                var json = JsonSerializer.Serialize(item);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("Item/Create", content);
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"Item/Delete/{id}");
        }

        public async Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            var response = await httpClient.GetAsync("Item/");
            if (response.IsSuccessStatusCode)
            {
                var items = await response.Content.ReadFromJsonAsync<IEnumerable<ItemModel>>();
                if (items is not null)
                {
                    return items!;
                }

            }

            return new List<ItemModel>();
        }

        public async Task<ItemModel> GetItemByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"Item/{id}");
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadFromJsonAsync<ItemModel>();
                if (item is not null)
                {
                    return item;
                }
            }

            return new ItemModel();
        }

        public async Task UpdateItemAsync(ItemModel item)
        {
            var json = JsonSerializer.Serialize(item);

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("Item/Update", content);
        }
    }
}
