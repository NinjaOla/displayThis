using Sanity.Linq;
using System.Text.Json;
using Vanir.Website.Models;

namespace Vanir.Website.Services
{
    public class PersonService
    {
        private readonly SanityDataContext _dbc;
        public PersonService(SanityDataContext dbc)
        {
            _dbc = dbc;
        }

        public Task<List<Person>> GetPersons()
        {
            return Task.FromResult(Persons.ToList());
        }

        public async Task<Person?> GetPerson(string slug)
        {
            return await Persons.Where(p => p.Slug.Current == slug).FirstOrDefaultAsync();
        }
        private SanityDocumentSet<Person> Persons => _dbc.DocumentSet<Person>();

        private async Task<List<Person>> GetFromFile()
        {
            return JsonSerializer.Deserialize<List<Person>>(await File.ReadAllTextAsync("teamsData.json"));
        }
    }
}
