using System.Runtime.InteropServices;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ICommentService
    {
        public Task CreateComment(CommentModel comment);

        public Task<IEnumerable<CommentModel>> GetAllItemsComments(int id);
    }
}
