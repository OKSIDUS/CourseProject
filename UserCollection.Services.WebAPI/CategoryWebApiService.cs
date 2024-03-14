using System.Net.Http.Json;
using System.Text.Json;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.WebAPI
{
    public class CategoryWebApiService : ICategoryService
    {
        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://userCollectionWebApi.somee.com"),
        };

        public async Task AddCategoryAsync(CollectionCategoryModel category)
        {
            if (category is not null)
            {
                var json = JsonSerializer.Serialize(category);

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("Category/Create", content);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"Category/Delete/{id}");
        }

        public async Task<IEnumerable<CollectionCategoryModel>> GetAllCategoriesAsync()
        {
            var response = await httpClient.GetAsync("Category/");
            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<IEnumerable<CollectionCategoryModel>>();
                return categories;
            }

            return new List<CollectionCategoryModel>();
        }

        public async Task<CollectionCategoryModel> GetCategoryAsync(int id)
        {
            var response = await httpClient.GetAsync($"Category/{id}");

            if (response.IsSuccessStatusCode)
            {
                var category = await response.Content.ReadFromJsonAsync<CollectionCategoryModel>();
                if (category is not null)
                {
                    return category;
                }
            }

            return new CollectionCategoryModel();
        }

        public async Task UpdateCategoryAsync(CollectionCategoryModel category)
        {
            var json = JsonSerializer.Serialize(category);

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"Category/Update/", content);
        }
    }
}
