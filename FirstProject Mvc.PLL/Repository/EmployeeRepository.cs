using FirstProject_Mvc.DAL.Data;
using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.PLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.Repository
{
	public class EmployeeRepository : GenericRepoisory<Employee>,IEmployeeRepository
	{
		private readonly ApplicationDbContext _application;

		public EmployeeRepository(ApplicationDbContext application):base(application)
        {
			_application = application;
		}

		public IQueryable<Employee> GetEmpByAddress(string address)
		{
			return _application.Employee.Where(e => e.Address == address);
		}

		#region MyRegion
		//      public EmployeeRepository(ApplicationDbContext _Dbcontext)
		//      {
		//	Dbcontext = _Dbcontext;
		//}

		//public ApplicationDbContext Dbcontext { get; }

		//public int Add(Employee employee)
		//{

		//	Dbcontext.Employee.Add(employee);
		// return	Dbcontext.SaveChanges();
		//}

		//public int Delete(Employee employee)
		//{
		//	Dbcontext.Employee.Remove(employee);
		//	return Dbcontext.SaveChanges();

		//}

		//public Employee Get(int id)
		//=> Dbcontext.Employee.Find(id);

		//public IEnumerable<Employee> GetAll()
		//{
		//	return Dbcontext.Employee.ToList();
		//}

		//public int Update(Employee employee)
		//{
		//	Dbcontext.Employee.Update(employee);
		//	return Dbcontext.SaveChanges();

		//} 
		#endregion

	}
}
