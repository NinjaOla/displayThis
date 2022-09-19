
using Sanity.Linq;
using System.Text.Json;
using Vanir.Website.Models;

namespace Vanir.Website.Services
{
    public class TeamsService
    {
        private readonly SanityDataContext _dbc;
        public TeamsService(SanityDataContext db)
        {
            _dbc = db;
        }

        public Task<IEnumerable<Team>> GetTeams(bool includeMembers = false)
        {
            var teams = Teams;

            if (includeMembers)
            {
                teams = teams.Include(t => t.Members);
            }

            return Task.FromResult(teams.AsEnumerable());
        }

        public async Task<Team?> GetTeam(string slug, bool includeMembers = false)
        {
            var team = Teams.Where(t => t.Slug.Current == slug);

            if (includeMembers)
            {
                team = team.Include(t => t.Members);
            }

            return await team.FirstOrDefaultAsync();
        }

        private SanityDocumentSet<Team> Teams => _dbc.DocumentSet<Team>();

        private async Task<List<Team>> GetFromFile()
        {
            return JsonSerializer.Deserialize<List<Team>>(await File.ReadAllTextAsync("teamsData.json"));
        }
    }
}
