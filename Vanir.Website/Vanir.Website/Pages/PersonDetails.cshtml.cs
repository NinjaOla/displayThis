using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vanir.Website.Models;

namespace Vanir.Website.Pages
{
    public class PersonDetailsModel : PageModel
    {

        public Person Person { get; set; }
        public async Task<IActionResult> OnGet()
        {
            await Task.Delay(1);
            return Page();
        }
    }
}
