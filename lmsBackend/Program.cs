using System.Text.Json.Serialization;
using lmsBackend.AutomapperProfile;
using lmsBackend.DataAccessLayer;
using lmsBackend.Repository.AdminRepo;
using lmsBackend.Repository.CategoriesRepo;
using lmsBackend.Repository.CourseRepo;
using lmsBackend.Repository.LobRepo;
using lmsBackend.Repository.ModuleRepo;
using lmsBackend.Repository.RoleRepo;
using lmsBackend.Repository.SmeRepo;
using lmsBackend.Repository.UserRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Handle circular references in JSON serialization
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(Options => {
    Options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IAdmin, AdminService>();
builder.Services.AddScoped<ISme, SmeService>();
builder.Services.AddScoped<ILob, LobService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IRole, RoleService>();
builder.Services.AddScoped<Icategories, CategoriesService>();
builder.Services.AddScoped<ICourse,CourseService>();
builder.Services.AddScoped<IModule, ModuleService>();



builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add services to the container.

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

// Enable CORS before routing
app.UseCors("AllowAll");

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
