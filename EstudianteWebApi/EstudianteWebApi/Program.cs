using DataBase;
//using Pomelo.
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EstudianteWebApi.Services;
//using MySQL.Data.EntityFrameworkCore.Extensions;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica",
                      policy  =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceEstudiante,ServicioEstudiante>();
builder.Services.AddScoped<IServiceMateria,ServicioMateria>();
builder.Services.AddScoped<IServiceProfesor,ServiceProfesor>();
builder.Services.AddScoped<IservicioDetalle,ServicioDetalle>();

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

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();

app.UseCors("NuevaPolitica");
app.UseAuthorization();

app.MapControllers();

app.Run();
