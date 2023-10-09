using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public interface ITeamRepository
    {
        int Add(Team team);
        Team? GetById(int id);
        List<Team> GetTeams(bool includeAll = false);
        void Update(Team team, bool isDeleted);
        void Update(Team oldTeam, Team newTeam);
    }
}