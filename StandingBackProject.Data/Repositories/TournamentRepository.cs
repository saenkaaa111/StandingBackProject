using Microsoft.EntityFrameworkCore;
using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly StandingContext _context;
        public TournamentRepository(StandingContext context)
        {
            _context = context;
        }

        public List<Tournament> GetTournaments() => _context.Tournament
                                                            .Include(o => o.Club)
                                                            .Include(o => o.Game)
                                                            .Include(o => o.Judge)
                                                            .Include(o => o.ResultTournamentPlayers)
                                                            .ToList();
        

        public Tournament? GetById(int id) => _context.Tournament.Include(o => o.ResultTournamentPlayers)
                                                            .Include(o => o.Club)
                                                            .Include(o => o.Game)
                                                            .Include(o => o.Judge)                                                           
                                                            .FirstOrDefault(x => x.Id == id);

        public int Add(Tournament tournament)
        {
            _context.Tournament.Add(tournament);
            _context.SaveChanges();
            return tournament.Id;
        }
        public void Update(Tournament oldTournament, Tournament newTournament)
        {
            oldTournament.Date = newTournament.Date;
            oldTournament.Status = newTournament.Status;
            oldTournament.Club = newTournament.Club;
            oldTournament.Judge = newTournament.Judge;
            _context.SaveChanges();
        }

    }
}