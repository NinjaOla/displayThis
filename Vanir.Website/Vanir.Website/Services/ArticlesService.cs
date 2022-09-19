using Sanity.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vanir.Website.Models;

namespace Vanir.Website.Services
{



    public class ArticlesService
    {
        private readonly SanityDataContext _dbc;
        private readonly OMCache _cache;
        public ArticlesService(SanityDataContext dbc, OMCache cache)
        {
            this._dbc = dbc;
            _cache = cache;
        }

        public Task<IEnumerable<Article>> GetArticles()
        {


            return Task.FromResult(Articles.Include(a => a.Author).AsEnumerable());
        }

        public async Task<Article?> GetArticle(string slug)
        {

            var article = await Articles.Where(a => a.Slug.Current == slug).FirstOrDefaultAsync();

            return article;
        }


        private SanityDocumentSet<Article> Articles => _dbc.DocumentSet<Article>();
    
        private async Task<List<Article>> ArticlesToList()
        {
            return JsonSerializer.Deserialize<List<Article>>(await File.ReadAllTextAsync(@"articles.json"));
        }


    }
}
