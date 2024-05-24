using MAUIDemo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        public required SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDatabase()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Employee.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Employee>();
            }
        }

        public async Task<List<Employee>> GetEmployeesList()
        {
            await SetUpDatabase();
            return await _dbConnection.Table<Employee>().ToListAsync(); ;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            await SetUpDatabase();
            return await _dbConnection.InsertAsync(employee);
        }

        public async Task<int> DeleteEmployee(Employee employee)
        {
            await SetUpDatabase();
            return await _dbConnection.DeleteAsync(employee);
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            await SetUpDatabase();
            return await _dbConnection.UpdateAsync(employee);
        }
    }
}
