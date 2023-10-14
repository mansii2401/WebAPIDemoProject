using WebAPIDemoProject.Repositories;
using WebAPIDemoProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
// repository
builder.Services.AddSingleton<UserDetailRepository>();
builder.Services.AddSingleton<UserCredentialRepository>();
builder.Services.AddSingleton<ScoreListRepository>();

// service
builder.Services.AddSingleton<UserDetailService>();
builder.Services.AddSingleton<UserCredentialService>();
builder.Services.AddSingleton<ScoreListService>();

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
