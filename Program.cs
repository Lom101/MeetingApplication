using MeetingApplication;
using MeetingApplication.Interfaces;
using MeetingApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


// 
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IMeetingService, DbMeetingService>();
builder.Services.AddScoped<ITwoService, DbTwoService>();
builder.Services.AddScoped<IPossibleToAddService, DbPossibleToAddService>();
builder.Services.AddScoped<IEmployeeService, DbEmployeeService>();
builder.Services.AddScoped<IOrganizerService, DbOrganizerService>();
builder.Services.AddScoped<IMeetingEmployeeService, DbMeetingEmployeeService>();


builder.Services.AddDbContext<MeetingApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration["CONNECTION_STRING"]);
});

//   PossibleToAdd?meetingId=1&roleId=1
//   Organizers?meetingId=1&roleId=1

//   MeetingEmployee?meetingId=1&employeeId=1&roleId=2
//   MeetingEmployees/AddMeetingEmployee?meetingId=1&employeeId=1&roleId=3
//   MeetingEmployees/GetMeetingEmployee

var app = builder.Build();
app.MapControllers();
app.Run();







// сделать вывод организатора
// сделать возможность добавления организатора
// один человек не может присутствовать на двух совещаниях одновременно
// разделить обращение к бд и вычисление результатов(разные зоны ответственности)

// проверить при добавлении пользователи не присутствует ли он в этот момент на другом совещании