using Crud_with_mongodb.Models;
using Namespace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DbConfiguration>(
    builder.Configuration.GetRequiredSection("Client-Connection")
);

builder.Services.AddSingleton<UserDAL>();
builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
