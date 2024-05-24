using CommunityToolkit.Mvvm.Input;
using MAUIDemo.Models;
using MAUIDemo.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIDemo.ViewModels
{
    public partial class EmployeesViewModel : ObservableObject
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public readonly IEmployeeService _employeeService;
        public EmployeesViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [ICommand]
        public async void GetEmployeeList()
        {
            var employees = await _employeeService.GetEmployeesList();
            if (employees?.Count > 0) 
            {
                Employees.Clear();
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
        }
        [ICommand]
        public async void AddUpdateEmployee()
        {
            await AppShell.Current.GoToAsync(nameof(AddEmployee));
        }
    }
}
