using System.Runtime.InteropServices;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Interfaces
{
    public interface ICommentService
    {
        public Task CreateComment(CommentModel commet);

        public Task<IEnumerable<CommentModel>> GetAllItemsComments(int id);
    }
}
