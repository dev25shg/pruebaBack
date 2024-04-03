using DataBase;
//using Pomelo.
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using MySQL.Data.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InstitutoContext>(options =>
{    
    options.UseMySql(builder.Configuration.GetConnectionString("InstitutoConection"), new MySqlServerVersion(new Version(8, 0, 36)));
   
});

var app = builder.Build();
/*
using (var scope = app.Services.CreateScope())
{
    var dataconn = scope.ServiceProvider.GetRequiredService<InstitutoContext>();
    dataconn.Database.Migrate();
} */

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
