using System.Net.Http.Json;
using System.Text.Json;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.WebAPI
{
    public class CollectionWebApiService : ICollectionService
    {
        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://userCollectionWebApi.somee.com"),
        };

        public async Task AddCollectionAsync(CollectionModel collection)
        {
            if (collection is not null)
            {
                var json = JsonSerializer.Serialize(collection);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("Collection/Create", content);
            }
        }

        public async Task DeleteCollectionAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"Collection/Delete/{id}");
        }

        public async Task<IEnumerable<CollectionModel>> GetAllCollectionsAsync()
        {
            var response = await httpClient.GetAsync("Collection/");
            if (response.IsSuccessStatusCode)
            {
                var collections = await response.Content.ReadFromJsonAsync<IEnumerable<CollectionModel>>();
                if (collections is not null)
                {
                    return collections!;
                }
                
            }

            return new List<CollectionModel>();
        }

        public async Task<CollectionModel> GetCollectionAsync(int id)
        {
            var response = await httpClient.GetAsync($"Collection/{id}");
            if (response.IsSuccessStatusCode)
            {
                var collection = await response.Content.ReadFromJsonAsync<CollectionModel>();
                if(collection is not null)
                {
                    return collection;
                }
            }

            return new CollectionModel();
        }

        public async Task UpdateCollectionAsync(CollectionModel collection)
        {
            var json = JsonSerializer.Serialize(collection);

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("Collection/Update", content);
        }
    }
}
