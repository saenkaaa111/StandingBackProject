using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;

namespace StandingBackProject.Business
{
    public class BusinessLayerMapper : Profile
    {
        public BusinessLayerMapper()
        {
            CreateMap<Club, ClubModel>().ReverseMap();
            CreateMap<Game, GameModel>().ReverseMap();
            CreateMap<Person, PersonModel>().ReverseMap();
            CreateMap<ResultTournamentPlayer, ResultTournamentPlayerModel>().ReverseMap();
            CreateMap<Tournament, TournamentModel>().ReverseMap();
            
        }        
    }
}

