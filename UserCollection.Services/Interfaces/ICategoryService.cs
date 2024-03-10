using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(CollectionCategoryModel category);

        public Task UpdateCategoryAsync(CollectionCategoryModel category);

        public Task DeleteCategoryAsync(int id);

        public Task<CollectionCategoryModel> GetCategoryAsync(int id);

        public Task<IEnumerable<CollectionCategoryModel>> GetAllCategoriesAsync();
    }
}
