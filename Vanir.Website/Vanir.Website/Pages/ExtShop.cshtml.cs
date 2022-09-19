using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vanir.Website.Pages
{
    public class ExtShopModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public ExtShopModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}