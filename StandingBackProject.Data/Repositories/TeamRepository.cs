using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public class TeamRepository
    {
        private readonly StandingContext _context;

        public List<Team> GetTeams(bool includeAll = false) => _context.Team.Where(t => !t.isDeleted || includeAll).ToList();

        public Team? GetById(int id) => _context.Team.FirstOrDefault(x => x.Id == id);
                
        public int Add(Team team)
        {
            _context.Team.Add(team);
            _context.SaveChanges();
            return team.Id;
        }
        public void Update(Team oldTeam, Team newTeam)
        {
            oldTeam.Name = newTeam.Name;            

            _context.SaveChanges();
        }

        public void Update(Team team, bool isDeleted)
        {
            team.isDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}
