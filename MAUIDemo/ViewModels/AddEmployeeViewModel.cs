using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIDemo.Models;
using MAUIDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIDemo.ViewModels
{
    public partial class AddEmployeeViewModel : ObservableObject
    {
        private readonly IEmployeeService _employeeService;
        public AddEmployeeViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            EmployeeDetails = new Employee();  
        }

        [ObservableProperty]
        public Employee employeeDetails;

        [RelayCommand]
        public async void AddEmployee()
        {
            var response = await _employeeService.AddEmployee(employeeDetails);
            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Record Added", "Employee Details Added", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not Added", "Something went wrong", "OK");
            }

        }

    }
}
