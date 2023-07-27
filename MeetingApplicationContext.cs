using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using MeetingApplication.DTO;
using Microsoft.Extensions.Options;

public class MeetingApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<MeetingEmployee> MeetingEmployees { get; set; }
    public DbSet<MeetingQuestion> MeetingQuestions { get; set; }
    public DbSet<Role> Roles { get; set; }

    public MeetingApplicationContext(DbContextOptions<MeetingApplicationContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}