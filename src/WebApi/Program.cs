using Infrastructure.Extensions;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
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
app.UseCors("MyCors");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HikerDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Migrating database...");
    await dbContext.Database.MigrateAsync();
    logger.LogInformation("Database created successfully or already exists.");

}

await app.RunAsync();