﻿using EmployeeCQRS_AndMediatR.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCQRS_AndMediatR.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
           var result = _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var result = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
                   _context.Employees.Remove(result);
            return await _context.SaveChangesAsync();

        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            
        }

        public async Task<List<Employee>> GetEmployeesList()
        {
            return await _context.Employees.ToListAsync();
            
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
          return await _context.SaveChangesAsync();
        }
    }
}
