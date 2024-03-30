using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCollection.Services.Database.Entities;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Database.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IMapper mapper;

        public CommentService(ApplicationDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateComment(CommentModel commet)
        {
            if (commet is not null)
            {
                var commentEntity = mapper.Map<CommentEntity>(commet);
                await dbContext.Comments.AddAsync(commentEntity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CommentModel>> GetAllItemsComments(int id)
        {
            var comments = await dbContext.Comments.Where(c => c.ItemId == id).ToListAsync();
            return comments.Select(c => mapper.Map<CommentModel>(c));
        }
    }
}
