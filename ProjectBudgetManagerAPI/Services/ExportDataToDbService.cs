using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Config;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Helpers;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services.Interfaces;
using System;
using System.Globalization;
using System.Security.AccessControl;
using System.Text;

namespace ProjectBudgetManagerAPI.Services
{
    public class ExportDataToDbService : IExportDataToDbService
    {
        private readonly ProjectBudgetManagerDbContext _projectBudgetManagerDbContext;
        private readonly IImportAndDeserializeDataService _importAndDeserializeDataService;

        private IMapper _mapper;
        private EmployeesDS? _employeesDS = new EmployeesDS();

        public ExportDataToDbService(ProjectBudgetManagerDbContext projectBudgetManagerDbContext, IImportAndDeserializeDataService importAndDeserializeDataService, IMapper mapper)
        { 
            _projectBudgetManagerDbContext = projectBudgetManagerDbContext;
            _importAndDeserializeDataService = importAndDeserializeDataService;

            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task AddBudget()
        {
            HashSet<string> normalProjects = new HashSet<string>();
            HashSet<string> specialProjects = new HashSet<string>();

            Random rnd = new Random();

            foreach (var employee in _employeesDS.Employees)
            {
                foreach (var day in employee.Days)
                {
                    foreach (var normalProject in day.NormalProjects)
                    {
                        if (normalProject.Name != string.Empty)
                        {
                            var project = await _projectBudgetManagerDbContext.Projects.FirstOrDefaultAsync(p => p.Name == normalProject.Name);

                            BudgetDTO budgetDTO = new()
                            {
                                BudgetId = Guid.NewGuid(),
                                ProjectId = project.ProjectId,
                                InitialBudget = rnd.Next(10000, 99999),
                                SpentBudget = 0
                            };

                            if (!normalProjects.Contains(normalProject.Name))
                            {
                                var mapped = _mapper.Map<BudgetDTO, Budget>(budgetDTO);

                                await _projectBudgetManagerDbContext.AddAsync(mapped);
                                await _projectBudgetManagerDbContext.SaveChangesAsync();

                                normalProjects.Add(normalProject.Name);
                            }
                        }
                    }
                    foreach (var specialProject in day.SpecialProjects)
                    {
                        if (specialProject.Name != string.Empty)
                        {
                            var project = await _projectBudgetManagerDbContext.Projects.FirstOrDefaultAsync(p => p.Name == specialProject.Name);

                            BudgetDTO budgetDTO = new()
                            {
                                BudgetId = Guid.NewGuid(),
                                ProjectId = project.ProjectId,
                                InitialBudget = rnd.Next(100000, 999999),
                                SpentBudget = 0
                            };

                            if (!specialProjects.Contains(specialProject.Name))
                            {
                                var mapped = _mapper.Map<BudgetDTO, Budget>(budgetDTO);

                                await _projectBudgetManagerDbContext.AddAsync(mapped);
                                await _projectBudgetManagerDbContext.SaveChangesAsync();

                                specialProjects.Add(specialProject.Name);
                            }
                        }
                    }
                }
            }
        }

        public async System.Threading.Tasks.Task AddEmployees()
        {
            foreach(var employee in _employeesDS.Employees)
            {
                EmployeeDTO employeeDTO = new()
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = employee.Name,
                    HourlyPay = employee.HourlyPay,
                };

                var mapped = _mapper.Map<EmployeeDTO, Employee>(employeeDTO);

                await _projectBudgetManagerDbContext.AddAsync(mapped);
                await _projectBudgetManagerDbContext.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task AddEmployeeTask()
        {
            foreach(var employee in _employeesDS.Employees)
            {
                var emp = await _projectBudgetManagerDbContext.Employees.FirstOrDefaultAsync(e => e.Name == employee.Name);

                foreach (var day in employee.Days)
                {
                    foreach(var normalProject in day.NormalProjects) 
                    {
                        if (normalProject.Name != string.Empty)
                        {
                            foreach (var task in normalProject.Tasks)
                            {
                                var tsk = await _projectBudgetManagerDbContext.Tasks.FirstOrDefaultAsync(t => t.Name == task.Name);

                                EmployeeTaskDTO taskDTO = new()
                                {
                                    EmployeeTaskId = Guid.NewGuid(),
                                    EmployeeId = emp.EmployeeId,
                                    TaskId = tsk.TaskId,
                                    Hours = task.Hours,
                                    Date = DateTime.ParseExact(day.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                };

                                var mapped = _mapper.Map<EmployeeTaskDTO, EmployeeTask>(taskDTO);

                                await _projectBudgetManagerDbContext.AddAsync(mapped);
                                await _projectBudgetManagerDbContext.SaveChangesAsync();
                            }
                        }
                    }
                    foreach (var specialProject in day.SpecialProjects)
                    {
                        if (specialProject.Name != string.Empty)
                        {
                            foreach (var task in specialProject.Tasks)
                            {
                                var tsk = await _projectBudgetManagerDbContext.Tasks.FirstOrDefaultAsync(t => t.Name == task.Name);

                                EmployeeTaskDTO taskDTO = new()
                                {
                                    EmployeeTaskId = Guid.NewGuid(),
                                    EmployeeId = emp.EmployeeId,
                                    TaskId = tsk.TaskId,
                                    Hours = task.Hours,
                                    Date = DateTime.ParseExact(day.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                };

                                var mapped = _mapper.Map<EmployeeTaskDTO, EmployeeTask>(taskDTO);

                                await _projectBudgetManagerDbContext.AddAsync(mapped);
                                await _projectBudgetManagerDbContext.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
        }

        public async System.Threading.Tasks.Task AddProjects()
        {
            HashSet<string> normalProjects = new();
            HashSet<string> specialProjects = new();

            foreach(var employee in _employeesDS.Employees)
            {
                foreach(var day in employee.Days)
                {
                    foreach(var normalProject in day.NormalProjects) 
                    {
                        if (normalProject.Name != string.Empty)
                        {
                            ProjectDTO projectDTO = new()
                            {
                                ProjectId = Guid.NewGuid(),
                                Name = normalProject.Name,
                                IsSpecial = false
                            };

                            if (!normalProjects.Contains(normalProject.Name))
                            {
                                var mapped = _mapper.Map<ProjectDTO, Project>(projectDTO);

                                await _projectBudgetManagerDbContext.AddAsync(mapped);
                                await _projectBudgetManagerDbContext.SaveChangesAsync();

                                normalProjects.Add(normalProject.Name);
                            }
                        }
                    }
                    foreach(var specialProject in day.SpecialProjects)
                    {
                        if (specialProject.Name != string.Empty)
                        {
                            ProjectDTO projectDTO = new()
                            {
                                ProjectId = Guid.NewGuid(),
                                Name = specialProject.Name,
                                IsSpecial = true
                            };

                            if (!specialProjects.Contains(specialProject.Name))
                            {
                                var mapped = _mapper.Map<ProjectDTO, Project>(projectDTO);

                                await _projectBudgetManagerDbContext.AddAsync(mapped);
                                await _projectBudgetManagerDbContext.SaveChangesAsync();

                                specialProjects.Add(specialProject.Name);
                            }
                        }
                    }
                }
            }
        }

        public async System.Threading.Tasks.Task AddTasks()
        {
            HashSet<string> tasks = new();

            foreach (var employee in _employeesDS.Employees)
            {
                foreach (var day in employee.Days)
                {
                    foreach (var normalProject in day.NormalProjects)
                    {
                        if (normalProject.Name != string.Empty)
                        {
                            foreach (var task in normalProject.Tasks)
                            {
                                var project = await _projectBudgetManagerDbContext.Projects.FirstOrDefaultAsync(p => p.Name == normalProject.Name);

                                TaskDTO taskDTO = new()
                                {
                                    TaskId = Guid.NewGuid(),
                                    ProjectId = project.ProjectId,
                                    Name = task.Name,
                                    Price = 0,
                                    IsDone = false
                                };

                                if (!tasks.Contains(task.Name))
                                {
                                    var mapped = _mapper.Map<TaskDTO, Models.Task>(taskDTO);

                                    await _projectBudgetManagerDbContext.AddAsync(mapped);
                                    await _projectBudgetManagerDbContext.SaveChangesAsync();

                                    tasks.Add(task.Name);
                                }
                            }
                        }
                    }
                    foreach (var specialProject in day.SpecialProjects)
                    {
                        if (specialProject.Name != string.Empty)
                        {
                            foreach (var task in specialProject.Tasks)
                            {
                                var project = await _projectBudgetManagerDbContext.Projects.FirstOrDefaultAsync(p => p.Name == specialProject.Name);

                                TaskDTO taskDTO = new()
                                {
                                    TaskId = Guid.NewGuid(),
                                    ProjectId = project.ProjectId,
                                    Name = task.Name,
                                    Price = task.Price,
                                    IsDone = false
                                };

                                if (!tasks.Contains(task.Name))
                                {
                                    var mapped = _mapper.Map<TaskDTO, Models.Task>(taskDTO);

                                    await _projectBudgetManagerDbContext.AddAsync(mapped);
                                    await _projectBudgetManagerDbContext.SaveChangesAsync();

                                    tasks.Add(task.Name);
                                }
                            }
                        }
                    }
                }
            }
        }

        public async System.Threading.Tasks.Task AddWeeklySalary()
        {
            foreach(var employee in _employeesDS.Employees) 
            {
                var emp = await _projectBudgetManagerDbContext.Employees.FirstOrDefaultAsync(e => e.Name == employee.Name);

                DateTime startDate = DateTime.ParseExact(employee.Days.First().Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(employee.Days.Last().Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                WeeklySalaryDTO weeklySalaryDTO = new()
                {
                    WeeklySalaryId = Guid.NewGuid(),
                    EmployeeId = emp.EmployeeId,
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalHours = employee.TotalHours,
                    GrossAmount = employee.GrossAmount,
                    GrossAmountAfterTax = employee.GrossAmount - employee.Tax,
                    IsPaid = false
                };

                var mapped = _mapper.Map<WeeklySalaryDTO, WeeklySalary>(weeklySalaryDTO);

                await _projectBudgetManagerDbContext.AddAsync(mapped);
                await _projectBudgetManagerDbContext.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task AddAllData(EmployeesDS employeesDS)
        {
            _employeesDS = employeesDS;

            await AddEmployees();
            await AddProjects();
            await AddBudget();
            await AddTasks();
            await AddEmployeeTask();
            await AddWeeklySalary();
        }

        public System.Threading.Tasks.Task UpdateWeeklySalaryIsPaid(string employeeName, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
