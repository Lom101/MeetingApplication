using MeetingApplication;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using MeetingApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddScoped<CustomExceptionFilterAttribute>();
builder.Services.AddScoped<IMeetingService, DbMeetingService>();
builder.Services.AddScoped<IEmployeeService, DbEmployeeService>();
builder.Services.AddScoped<IMeetingEmployeeService, DbMeetingEmployeeService>();

builder.Services.AddDbContext<MeetingApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration["CONNECTION_STRING"]);
});

var app = builder.Build();
app.MapControllers();
app.Run();

//  MeetingEmployee/EmployeeInAnotherMeetingCheck/8