

using Application.DTO;
using Application.Interfaces;
using Application.IPublishers;
using Application.Services;
using Domain.Factory;
using Domain.IRepository;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Resolvers;
using InterfaceAdapters.Consumers;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using WebApi.Publishers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PadelBookingContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

//Services
builder.Services.AddTransient<ICourtService, CourtService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IClubService, ClubService>();

builder.Services.AddTransient<IMessagePublisher, MassTransitPublisher>();

//Repositories
builder.Services.AddTransient<ICourtRepository, CourtRepository>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();
builder.Services.AddTransient<IClubRepository, ClubRepository>();

//Factories
builder.Services.AddTransient<ICourtFactory, CourtFactory>();
builder.Services.AddTransient<IBookingFactory, BookingFactory>();
builder.Services.AddTransient<IClubFactory, ClubFactory>();

//Mappers
builder.Services.AddTransient<CourtDataModelConverter>();
builder.Services.AddTransient<BookingDataModelConverter>();
builder.Services.AddTransient<ClubDataModelConverter>();
builder.Services.AddAutoMapper(cfg =>
{
    //DataModels
    cfg.AddProfile<DataModelMappingProfile>();

    //DTO
    cfg.CreateMap<Booking, BookingDTO>();
    cfg.CreateMap<Booking, CreateBookingDTO>();

});

// MassTransit

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CourtCreatedConsumer>();
    x.AddConsumer<ClubCreatedConsumer>();
    x.AddConsumer<BookingCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", 5673, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("bookings-cmd", e =>
{
    e.ConfigureConsumer<CourtCreatedConsumer>(context);
    e.ConfigureConsumer<ClubCreatedConsumer>(context);

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
