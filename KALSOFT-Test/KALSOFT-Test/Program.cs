using KALSOFT_Test.DataContext;
using KALSOFT_Test.Repositories.Abstract.IRepository;
using KALSOFT_Test.Repositories.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("AppCon"),
        ServerVersion.Parse("8.0.35-mysql"));
    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(
                                            "Allow Origin", options => options
                                            .AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyHeader()));
//Json Serialization
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
     = new DefaultContractResolver());

//Registering Services
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IPropertiesDetailRepository, PropertiesDetailsRepository>();
builder.Services.AddScoped<IExposureRepository, ExposureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
