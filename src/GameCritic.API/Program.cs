using GameCritic.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServices();
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
