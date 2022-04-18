using MerchantsApi.Database;
using MerchantsApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//adding MerchantRepository
builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
//adding StoreRepository
builder.Services.AddScoped<IStoreRepository, StoreRepository>();

//adding the DataBase (inMemory)
//builder.Services.AddDbContext<MerchantDbContext>(opt => opt.UseInMemoryDatabase("MerchantsDB"));

builder.Services.AddDbContext<MerchantDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.MapControllers();

app.UseCors(
    options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
    );

app.Run();


