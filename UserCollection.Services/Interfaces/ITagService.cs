using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ITagService
    {
        public Task AddTag(TagModel tag);

        public Task UpdateTag(TagModel tag);

        public Task DeleteTag(TagModel tag);

        public Task<TagModel> GetTagById(int id);

        public Task<IEnumerable<TagModel>> GetAll();
    }
}
