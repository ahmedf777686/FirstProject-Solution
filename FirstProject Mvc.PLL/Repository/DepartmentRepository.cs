using FirstProject_Mvc.DAL.Data;
using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.PLL.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.Repository
{
    public class DepartmentRepository : IdepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext _context)
        {
            Context = _context;
        }

        public ApplicationDbContext Context { get; }

        public int Add(Department department)
        {
            Context.departments.Add(department);
            return Context.SaveChanges();
        }

        public int Delete(Department department)
        {
            Context.departments.Remove(department);
            return Context.SaveChanges();
        }

        public Department Get(int id)
        {
           return Context.departments.Where(d => d.ID == id).First();
        }

        public IEnumerable<Department> GetAll()
        {
            return Context.departments.AsNoTracking().ToList();
        }

        public int Update(Department department)
        {
            Context.departments.Update(department);
            return Context.SaveChanges();
        }
    }
}
