using FunBooksAndVideos.Infrastructure;
using FunBooksAndVideos.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "FunBooksAndVideos.Api", Version = "v1" });
});
builder.Services.AddControllers();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FunBooksAndVideos.Api v1"));
}

app.UseHttpsRedirection();
app.Run();