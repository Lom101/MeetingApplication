using MeetingApplication;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using MeetingApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IMeetingService, DbMeetingService>();
builder.Services.AddScoped<IEmployeeService, DbEmployeeService>();
builder.Services.AddScoped<IMeetingEmployeeService, DbMeetingEmployeeService>();


builder.Services.AddDbContext<MeetingApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration["CONNECTION_STRING"]);
});

// MeetingEmployee/PossibleToAddOrganizer

//   MeetingEmployee/GetMeetingEmployee
//   MeetingEmployee/AddMeetingEmployee?meetingId=1&employeeId=1&roleId=3
//   MeetingEmployee/PossibleToAddOrganizer?meetingId=1
//   MeetingEmployee/EmployeeInAnotherMeetingCheck?employeeId=1
//   MeetingEmployee/GetOrganizer?meetingId=1

//   Meeting/GetMeetings
//   Meeting/GetMeetingsUnited

var app = builder.Build();
app.MapControllers();
app.Run();