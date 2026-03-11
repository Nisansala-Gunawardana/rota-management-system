using Microsoft.EntityFrameworkCore;
using NurserySystem_AttendanceAPI.Data;
using NurserySystem_AttendanceAPI.UnitOfWork;
using NurserySystem_AttendanceAPI.UnitOfWork.UOWImplementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AttendanceDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AttendDbConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
