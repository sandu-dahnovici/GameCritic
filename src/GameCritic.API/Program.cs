using GameCritic.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServices();
var app = builder.Build();

await app.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAny");

app.UseRequestLogging();

app.UseExceptionHandling();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseDbTransaction();

app.MapControllers();

await app.RunAsync();












public partial class Program
{
}