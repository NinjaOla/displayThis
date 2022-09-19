using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vanir.Website.Models;
using Vanir.Website.Services;

namespace Vanir.Website.Pages
{
    public class TeamsListModel : PageModel
    {
        private TeamsService _teamService { get; }

       
        public TeamsListModel(TeamsService teamService)
        {
            _teamService = teamService;
        }

        public List<Team> Teams { get; set; } = new List<Team>();
        public async Task<IActionResult>  OnGet()
        {
            var enumberable = await _teamService.GetTeams();
            enumberable = enumberable.Where(t => t.IsPublic == true);
            Teams = enumberable.ToList();
            return Page();
        }
    }
}
