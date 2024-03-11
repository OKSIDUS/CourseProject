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

        public async Task AddTag(TagModel tag)
        {
            if ((tag is not null) && (await CheckItem(tag.ItemId)))
            {
                var tagEntity = mapper.Map<TagEntity>(tag);
                await dbContext.Tags.AddAsync(tagEntity);
                var itemTagsEntity = new ItemsTagsEntity
                {
                    TagId = tag.ItemId,
                    ItemId = tag.ItemId,
                };
                await dbContext.ItemsTags.AddAsync(itemTagsEntity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteTag(TagModel tag)
        {
            if (tag is not null)
            {
                var tagEntity = mapper.Map<TagEntity>(tag);
                dbContext.Tags.Remove(tagEntity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TagModel>> GetAll()
        {
            var tags = await dbContext.Tags.ToListAsync();
            return tags.Select(t => mapper.Map<TagModel>(t));
        }

        public async Task<TagModel> GetTagById(int id)
        {
            var tag = await dbContext.Tags.Where(t => t.Id == id).FirstOrDefaultAsync();
            return mapper.Map<TagModel>(tag);
        }

        public async Task UpdateTag(TagModel tag)
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
