using AutoMapper;
using UserCollection.Services.Database.Entities;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Database.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(ApplicationDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddCategoryAsync(CollectionCategoryModel category)
        {
            if (category is not null)
            {
                var categoryEntity = mapper.Map<CategoryEntity>(category);
                await dbContext.AddAsync(categoryEntity);
                await dbContext.SaveChangesAsync();
            }
        }

        public Task DeleteCategoryAsync(CollectionCategoryModel category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CollectionCategoryModel>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CollectionCategoryModel> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(CollectionCategoryModel category)
        {
            throw new NotImplementedException();
        }
    }
}
