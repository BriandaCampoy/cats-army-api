using cats_army_api.Models;
using cats_army_api.services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<CatStoreDatabaseSettings>(
    builder.Configuration.GetSection("CatsDatabaseSettings")
);

// builder.Services.AddSingleton<CatService>();
builder.Services.AddSingleton<ICatStoreDatabaseSettings>(sp=>
sp.GetRequiredService<IOptions<CatStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s=> 
    new MongoClient(builder.Configuration.GetValue<string>("CatsDatabaseSettings:ConnectionString"))
);



builder.Services.AddScoped<ICatService, CatService>();
builder.Services.AddScoped<ICatTypeService, CatTypeService>();
builder.Services.AddScoped<ISquadService, SquadService>();

builder.Services.AddCors(options =>{
    options.AddPolicy("AllowCorsPolicy",
        builder => {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

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
app.UseCors("AllowCorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
