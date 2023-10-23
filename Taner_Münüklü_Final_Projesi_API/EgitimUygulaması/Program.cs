using EgitimApp.Business.Abstract;
using EgitimApp.Business.Concrete;
using EgitimApp.Data.Abstract;
using EgitimApp.Data.Concrete.EfCore.Contexts;
using EgitimApp.Data.Concrete.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EducationAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<ICourseService, CourseManager>();
builder.Services.AddScoped<ITraineeService, TraineeManager>();
builder.Services.AddScoped<ITrainerService, TrainerManager>();  
builder.Services.AddScoped<ISettingsService, SettingsManager>();

builder.Services.AddScoped<ICourseRepository, EfCoreCourseRepository>();
builder.Services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
builder.Services.AddScoped<ITrainerRepository,EfCoreTrainerRepository>();

builder.Services.AddScoped<ITraineeRepository, EfCoreTraineeRepository>();
builder.Services.AddScoped<ISettingsRepository, EfCoreSettingsRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "_allowAllPolicy",
        policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("_allowAllPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
