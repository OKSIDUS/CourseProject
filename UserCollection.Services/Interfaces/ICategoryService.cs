using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task AddCategory(CollectionCategoryModel category);

        public Task UpdateCategory(CollectionCategoryModel category);

        public Task DeleteCategory(CollectionCategoryModel category);

        public Task<CollectionCategoryModel> GetCategory(int id);

        public Task<IEnumerable<CollectionCategoryModel>> GetAllCategories();
    }
}
