using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCollection.Services.Database.Entities;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Database.Services
{
    public class TagService : ITagService
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IMapper mapper;

        public TagService(ApplicationDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddTagAsync(TagModel tag)
        {
            if ((tag is not null) && (await CheckItem(tag.ItemId)))
            {
                var tagEntity = mapper.Map<TagEntity>(tag);
                await dbContext.Tags.AddAsync(tagEntity);
                await dbContext.SaveChangesAsync();

                int newId = tagEntity.Id;
                var itemTagsEntity = new ItemsTagsEntity
                {
                    TagId = newId,
                    ItemId = tag.ItemId,
                };
                await dbContext.ItemsTags.AddAsync(itemTagsEntity);
                
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteTagAsync(int id)
        {
            var tag = await dbContext.Tags.Where(t => t.Id == id).FirstOrDefaultAsync();
            if (tag is not null)
            {
                dbContext.Tags.Remove(tag);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TagModel>> GetAllAsync()
        {
            var tags = await dbContext.Tags.ToListAsync();
            return tags.Select(t => mapper.Map<TagModel>(t));
        }

        public async Task<TagModel> GetTagByIdAsync(int id)
        {
            var tag = await dbContext.Tags.Where(t => t.Id == id).FirstOrDefaultAsync();
            return mapper.Map<TagModel>(tag);
        }

        public async Task UpdateTagAsync(TagModel tag)
        {
            if ((tag is not null) && (await CheckItem(tag.ItemId)))
            {
                var tagEntity = await dbContext.Tags.Where(t => t.Id == tag.Id).FirstOrDefaultAsync();
                if (tagEntity is not null)
                {
                    mapper.Map(tag, tagEntity);
                    dbContext.Tags.Update(tagEntity);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private async Task<bool> CheckItem(int itemId)
        {
            var item = await dbContext.Items.Where(i => i.Id == itemId).FirstOrDefaultAsync();
            return item != null;
        }
    }
}
