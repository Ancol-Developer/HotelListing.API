using HotelListing.API.Configurations;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HotelListingDbConnectionString");
builder.Services.AddDbContext<HotelListingDbContext>(option=>
{
    option.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cấu hình CROS
builder.Services.AddCors(option => {
    option.AddPolicy("AllowAll",
        b=>b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});
builder.Host.UseSerilog((ctx, lc)=> lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<ICountriesRepository,CountryRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
