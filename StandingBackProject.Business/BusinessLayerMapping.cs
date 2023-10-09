using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;

namespace StandingBackProject.Business
{
    public static class BusinessLayerMapper
    {
        private static Mapper? _instance;

        public static Mapper GetInstance()
        {
            if (_instance is null)
                InitializeInstance();
            return _instance!;
        }

        private static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Club, ClubModel>().ReverseMap();
                cfg.CreateMap<Game, GameModel>().ReverseMap();
                cfg.CreateMap<Person, PersonModel>().ReverseMap();
                cfg.CreateMap<ResultTournamentPlayer, ResultTournamentPlayerModel>().ReverseMap();
                cfg.CreateMap<ResultTournamentTeam, ResultTournamentTeamModel>().ReverseMap();
                cfg.CreateMap<Team, TeamModel>().ReverseMap();
                cfg.CreateMap<Tournament, TournamentModel>().ReverseMap();
                
            }));
        }
    }
}

