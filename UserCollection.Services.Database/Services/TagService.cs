using AutoMapper;
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

        public Task AddTag(TagModel tag)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTag(TagModel tag)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TagModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TagModel> GetTagById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTag(TagModel tag)
        {
            throw new NotImplementedException();
        }
    }
}
