using Microsoft.EntityFrameworkCore;
using SingleStudentApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// we reached here from the appsettings.cs and before that we were in the Data folder studentDbContext.cs
builder.Services.AddDbContext<studentDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentConnectionString")));

// after the above injection, we will run the migrations command
// Our Db context named studentDBContext is injected, we will use it in the future

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
