using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ITagService
    {
        public Task AddTagAsync(TagModel tag);

        public Task UpdateTagAsync(TagModel tag);

        public Task DeleteTagAsync(int id);

        public Task<TagModel> GetTagByIdAsync(int id);

        public Task<IEnumerable<TagModel>> GetAllAsync();
    }
}
