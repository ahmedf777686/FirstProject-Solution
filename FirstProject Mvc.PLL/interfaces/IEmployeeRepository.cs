using FirstProject_Mvc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.interfaces
{
	public interface IEmployeeRepository :IGenericReposiory<Employee>
	{

		public IQueryable<Employee>  GetEmpByAddress(string address);
		public IQueryable<Employee> GetEmployeeByName(String Name);
	}
}
