using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PrismExample.Models;

namespace PrismExample.Services
{
    public class PostsService
    {
        private HttpClient _Client = new HttpClient(); // Used to call APIs

        public async Task<ObservableCollection<Post>> GetPostsAsync()
        {
            var content = await _Client.GetStringAsync(AppSettings.PostsEndpoint);
            var posts = JsonConvert.DeserializeObject<ObservableCollection<Post>>(content);
            return posts;
        }
    }
}
