using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.interfaces
{
	public interface Iunitofwork
	{


		public IdepartmentRepository DepartmentRepository { get; set; }
		public IEmployeeRepository EmployeeRepository { get; set; }

		public int Complete();
	}
}
