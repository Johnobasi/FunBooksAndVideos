using FunBooksAndVideos.Infrastructure;
using FunBooksAndVideos.Application;
using FunBooksAndVideos.Api.Extensions;
using FunBooksAndVideos.Infrastructure.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "FunBooksAndVideos.Api", Version = "v1" });
});
builder.Services.AddControllers();
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

//if(args.Length == 1 && args[0]?.ToLower()=="seeddata")
//    SeedData(app);

// //Seed Data
//void SeedData(IHost app)
//{
//    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//    using (var scope = scopedFactory!.CreateScope())
//    {
//        var service = scope.ServiceProvider.GetService<DataSeeder>();
//        service?.SeedData();
//    }
//}
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FunBooksAndVideos.Api v1"));
}

app.UseHttpsRedirection();
app.Run();