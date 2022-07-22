using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TicketingSolution.Core.Handlers;
using TicketingSolution.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var connString = "DataSource=:memory:";
var conn = new SqliteConnection(connString);
conn.Open();
builder.Services.AddDbContext<TicketingSolutionDbContext>(opt => opt.UseSqlite(conn));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITickerBookingRequestHandler, TickerBookingRequestHandler>();
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
