using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sanity.Linq.BlockContent;
using Vanir.Website.Models;
using Vanir.Website.Services;

namespace Vanir.Website.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public readonly SanityHtmlBuilder _sHtmlBuilder;

        public ArticleDetailsModel(ArticlesService articleService, SanityHtmlBuilder sHtmlBuilder, VNRSanityServices sanityService)
        {
            _articleService = articleService;
            _sHtmlBuilder = sHtmlBuilder;
            SanityService = sanityService;
        }

        private ArticlesService _articleService { get; }
        public VNRSanityServices SanityService { get; }

        public Article Article { get; set; }



        [BindProperty(SupportsGet = true)]
        public string Slug { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (string.IsNullOrEmpty(Slug))
            {
                return NotFound();
            }
            Article = await _articleService.GetArticle(Slug);

            if(Article == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
