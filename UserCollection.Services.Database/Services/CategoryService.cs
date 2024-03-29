﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await dbContext.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(category is not null)
            {
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CollectionCategoryModel>> GetAllCategoriesAsync()
        {
            var categories = await dbContext.Categories.ToListAsync();
            return categories.Select(c => mapper.Map<CollectionCategoryModel>(c));
        }

        public async Task<CollectionCategoryModel> GetCategoryAsync(int id)
        {
            var category = await dbContext.Categories.Include(c=> c.UserCollections).Where(c => c.Id == id).FirstOrDefaultAsync();
            return mapper.Map<CollectionCategoryModel>(category);
        }

        public async Task UpdateCategoryAsync(CollectionCategoryModel category)
        {
            var categoryEntity = await dbContext.Categories.Where(c => c.Id == category.Id).FirstOrDefaultAsync();
            if (categoryEntity is not null)
            {
                mapper.Map(category, categoryEntity);

                dbContext.Categories.Update(categoryEntity);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
