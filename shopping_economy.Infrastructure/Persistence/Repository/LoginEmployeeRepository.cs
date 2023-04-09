using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace shopping_economy.Infrastructure.Persistence.Repository
{
    public class LoginEmployeeRepository : ILoginEmployeeRepository
    {   
        private readonly DataBaseContext _context;
        public LoginEmployeeRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task RegisterEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();
        }

        public async Task<Employee> CheckIfEmployeeExistsAsync(Employee employee)
        {
            var employeeUser = await _context.Employees.Where(p => p.Email == employee.Email && p.Password == employee.Password).FirstOrDefaultAsync();

            return employeeUser;
        }
        
        public async Task<bool> CheckIfEmailAlreadyExistsAsync(string email)
        {
            var usuario = await _context.Employees.FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());

            return usuario != null;
        }

        public async Task<int> BuscarIdAsync()
        {
            var id = await _context.Employees.Select(x => x.Id).FirstOrDefaultAsync();

            return id;
        }

        public async Task TypeUserClientAsync(int id)
        {
           var query = "UPDATE employees SET people_type = 'CLIENTE' WHERE employees.id = @id";

            await _context.Database.GetDbConnection().ExecuteAsync(query);
        }

        public async Task TypeUserEmployeeAsync(int id)
        {
            var query = "UPDATE employees SET people_type = 'FUNCIONARIO' WHERE employees.id = @id";

            await _context.Database.GetDbConnection().ExecuteAsync(query);
        }
    }
}