using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Models;
using System.Reflection.Emit;

namespace ProjectBudgetManagerAPI.Config
{
    public class ProjectBudgetManagerDbContext : DbContext
    {
        public ProjectBudgetManagerDbContext(DbContextOptions<ProjectBudgetManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WeeklySalary> WeeklySalaries { get; set; }
        public DbSet<Budget> Budget { get; set; }
    }
}
