using Application.DTO;
using Application.Services;
using Domain.Factory.ClubFactory;
using Domain.IRepository;
using Infrastructure;
using Infrastructure.Resolvers;
using Microsoft.EntityFrameworkCore;
using InterfaceAdapters.Publishers;
using MassTransit;
using Application.IPublishers;
using Domain.Models;
using InterfaceAdapters.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PadelBookingContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

//Services
builder.Services.AddTransient<IClubService, ClubService>();
builder.Services.AddScoped<IMessagePublisher, MassTransitPublisher>();

//Repositories
builder.Services.AddTransient<IClubRepository, ClubRepository>();

//Factories
builder.Services.AddTransient<IClubFactory, ClubFactory>();

//Mappers
builder.Services.AddTransient<ClubDataModelConverter>();
builder.Services.AddAutoMapper(cfg =>
{
    //DataModels
    cfg.AddProfile<DataModelMappingProfile>();

    //DTO
    cfg.CreateMap<Club, CreateClubDTO>();
});

// MassTransit

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ClubCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", 5673, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("clubs-cmd", e =>
{
    e.ConfigureConsumer<ClubCreatedConsumer>(context);
});

        cfg.ReceiveEndpoint("clubs-cmd-saga", e =>
        {
            e.ConfigureConsumer<CourtWithoutClubCreatedConsumer>(context);
        });

    });
});



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

// read env variables for connection string
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PadelBookingContext>();
    dbContext.Database.Migrate();
}

app.Run();

public partial class Program { }
