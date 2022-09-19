using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vanir.Website.Services;

namespace Vanir.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ArticlesService _articleService;

        public IndexModel(ILogger<IndexModel> logger, ArticlesService articleService)
        {
            _logger = logger;
            this._articleService = articleService;
        }

        public async Task<IActionResult> OnGet()
        {


            return Page();
        }
    }
}