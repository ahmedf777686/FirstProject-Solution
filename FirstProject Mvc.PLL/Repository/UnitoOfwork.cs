using FirstProject_Mvc.DAL.Data;
using FirstProject_Mvc.PLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.Repository
{
	public class UnitOfwork : Iunitofwork
	{



		public IdepartmentRepository DepartmentRepository { get ; set  ; }
		public IEmployeeRepository EmployeeRepository { get ; set; }
		public ApplicationDbContext _DbContext { get; }

		public UnitOfwork(ApplicationDbContext dbContext)
        {
			DepartmentRepository = new DepartmentRepository(dbContext);
			EmployeeRepository = new EmployeeRepository(dbContext);
			_DbContext = dbContext;
		}
        public int Complete()
		{
			return _DbContext.SaveChanges();
		}
	}
}
