using AutoMapper;
using StandingBackProject.API.Models.InputModels;
using StandingBackProject.API.Models.OutputModels;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;

namespace StandingBackProject.API;

public class APIMapping : Profile
{
    public APIMapping()
    {
        CreateMap<PersonInputModel, PersonModel>();
        CreateMap<PersonModel, PersonShortOutputModel>();
        CreateMap<PersonModel, PersonFullOutputModel>();

        CreateMap<ClubModel, ClubOutputModel>();
        CreateMap<ClubInputModel, ClubModel>();

        CreateMap<GameModel, GameOutputModel>();
        CreateMap<GameModel, GameFullOutputModel>();
        CreateMap<GameInputModel, GameModel>();

        CreateMap<TournamentModel, TournamentOutputModel>()
            .ForMember(tm => tm.ClubId, opt => opt.MapFrom(tim => tim.Club.Id))
            .ForMember(tm => tm.JudgeId, opt => opt.MapFrom(tim => tim.Judge.Id))
            .ForMember(tm => tm.GameId, opt => opt.MapFrom(tim => tim.Game.Id));

        CreateMap<TournamentInputModel, TournamentModel>()
            .ForMember(rtm => rtm.Judge, opt => opt.MapFrom(rtim => new PersonModel { Id = rtim.JudgeId }))
            .ForMember(rtm => rtm.Club, opt => opt.MapFrom(rtim => new ClubModel { Id = rtim.ClubId }))
            .ForMember(rtm => rtm.Game, opt => opt.MapFrom(rtim => new GameModel { Id = rtim.GameId }));
        CreateMap<TournamentShortInputModel, TournamentModel>()
            .ForMember(rtm => rtm.Judge, opt => opt.MapFrom(rtim => new PersonModel { Id = rtim.JudgeId }))
            .ForMember(rtm => rtm.Club, opt => opt.MapFrom(rtim => new ClubModel { Id = rtim.ClubId }));

        CreateMap<ResultTournamentPlayerModel, ResultTournamentPlayerOutputModel>()
            .ForMember(rtm => rtm.GameId, opt => opt.MapFrom(rtim => rtim.Game.Id))
            .ForMember(rtm => rtm.PersonId, opt => opt.MapFrom(rtim => rtim.Person.Id));
        
        CreateMap<ResultTournamentPlayerModel, ResultTournamentPlayerFullOutputModel>()
            .ForMember(rtm => rtm.GameId, opt => opt.MapFrom(rtim => rtim.Game.Id))
            .ForMember(rtm => rtm.PersonId, opt => opt.MapFrom(rtim => rtim.Person.Id));

        CreateMap<ResultTournamentPlayerInputModel, ResultTournamentPlayerModel>()
            .ForMember(rtm => rtm.Game, opt => opt.MapFrom(rtim => new GameModel { Id = rtim.GameId }))
            .ForMember(rtm => rtm.Tournament, opt => opt.MapFrom(rtim => new TournamentModel { Id = rtim.TournamentId }))
            .ForMember(rtm => rtm.Person, opt => opt.MapFrom(rtim => new PersonModel { Id = rtim.PersonId }));

    }
}