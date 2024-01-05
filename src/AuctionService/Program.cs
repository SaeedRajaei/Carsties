using AuctionService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AuctionService.Data.AuctionDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppConnection"));

});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());// Check all classes are derived from the AutoMapper.Profile


var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();
// try
// {
//     AuctionService.Data.DbInitializer.InitDb(app);
// }
// catch (Exception ex)
// {

//     Console.WriteLine(ex);
// }


try
{
    app.InitializeDatabase();
}
catch (Exception ex)
{

    Console.WriteLine(ex);
}

app.Run();
