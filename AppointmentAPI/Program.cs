using AppointmentAPI.Configuration;
using AppointmentAPI.DAO;
using AppointmentAPI.Data;
using AppointmentAPI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("AppointmentDBConnection");

// Add services to the container.
builder.Services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(connString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAppointmentDAO, AppointmentDAOImpl>();
builder.Services.AddScoped<IAppointmentService, AppointmentServiceImpl>();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy => policy.AllowAnyMethod()
                                                                                  .AllowAnyHeader()
                                                                                  .AllowAnyOrigin()));
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
