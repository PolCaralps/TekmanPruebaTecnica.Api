using Microsoft.EntityFrameworkCore;
using TekmanPruebaTecnica.Application.Interfaces;
using TekmanPruebaTecnica.Application.Interfaces.Repositories;
using TekmanPruebaTecnica.Application.Services;
using TekmanPruebaTecnica.Infrastructure;
using TekmanPruebaTecnica.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkInMemoryDatabase();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
    options.EnableSensitiveDataLogging(false);
}, ServiceLifetime.Singleton);

builder.Services.AddSingleton<AppSettings>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IUserNoteRepository, UserNoteRepository>();
builder.Services.AddScoped<ISetupRepository, SetupRepository>();

builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<ISetupApplicationService, SetupApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
