using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Sanity.Linq;
using Sanity.Linq.BlockContent;
using Vanir.Website.Models;
using Vanir.Website.Services;

namespace Vanir.Website.Pages
{
    public class TeamDetailsModel : PageModel
    {
        private TeamsService _teamService;
        public readonly VNRSanityServices _sServices;

        public TeamDetailsModel(TeamsService teamService, VNRSanityServices sServices)
        {
            _teamService = teamService;
            _sServices = sServices;
        }


        public Team Team { get; private set; }



        [BindProperty(SupportsGet = true)]
        public string Slug { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (string.IsNullOrWhiteSpace(Slug))
            {
                return NotFound();
            }
            Team = await _teamService.GetTeam(Slug, true);

            return Page();
        }
    }
}
