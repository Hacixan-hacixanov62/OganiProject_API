using Microsoft.EntityFrameworkCore;
using OganiProject_API.Middlewares;
using Repository;
using Repository.Data;
using Service;
using Service.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile(new MappingProfile());
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddRepositoryLayer();
builder.Services.AddServiceLayer();

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
