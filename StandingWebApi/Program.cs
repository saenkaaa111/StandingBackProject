using Microsoft.EntityFrameworkCore;
using StandingBackProject.API;
using StandingBackProject.API.StandingMiddleware;
using StandingBackProject.Business;
using StandingBackProject.Business.Services;
using StandingBackProject.Data;
using StandingBackProject.Data.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(BusinessLayerMapper).Assembly);
builder.Services.AddAutoMapper(new Assembly[] { Assembly.GetExecutingAssembly() });

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<IResultTournamentPlayerRepository, ResultTournamentPlayerRepository>();
builder.Services.AddScoped<IResultTournamentPlayerService, ResultTournamentPlayerService>();

builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ITournamentService, TournamentService>();

builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IClubService, ClubService>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddDbContext<StandingContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<StandingMiddleware>();

app.MapControllers();

app.Run();
