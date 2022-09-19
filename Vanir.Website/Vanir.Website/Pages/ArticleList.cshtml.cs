using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vanir.Website.Models;
using Vanir.Website.Services;

namespace Vanir.Website.Pages
{
    public class ArticleListModel : PageModel
    {

        public ArticleListModel(ArticlesService articleService)
        {
        }


        public List<Article> Articles { get; set; } = new List<Article>();

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}
