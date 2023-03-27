using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.Entities;

namespace shopping_economy.Core.Interface
{
    public interface ILoginEmployeeRepository
    {
        Task RegisterEmployeeAsync(Employee employee);
        Task<Employee> CheckIfEmployeeExistsAsync(Employee employee);
        Task<bool> CheckIfEmailAlreadyExistsAsync(string email);
        Task<int>BuscarIdAsync();
    }
}