using System.Net.Http.Json;
using System.Text.Json;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.WebAPI
{
    public class CommentWebApiService : ICommentService
    {
        private readonly HttpClient httpClient = new()
        {
            //BaseAddress = new Uri("http://userCollectionWebApi.somee.com/"),
            BaseAddress = new Uri("https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(200),
        };


        public async Task CreateComment(CommentModel comment)
        {
            if (comment is not null)
            {
                var json = JsonSerializer.Serialize(comment);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("Comment/Create", content);
            }
        }

        public async Task<IEnumerable<CommentModel>> GetAllItemsComments(int id)
        {
            var response = await httpClient.GetAsync($"Comment/{id}");
            if (response.IsSuccessStatusCode)
            {
                var collections = await response.Content.ReadFromJsonAsync<IEnumerable<CommentModel>>();
                if (collections is not null)
                {
                    return collections!;
                }

            }

            return new List<CommentModel>();
        }
    }
}
