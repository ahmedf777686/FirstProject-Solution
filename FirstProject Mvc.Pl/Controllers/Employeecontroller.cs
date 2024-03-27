using FirstProject_Mvc.PLL.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject_Mvc.Pl.Controllers
{
	public class Employeecontroller : Controller
	{
        public Employeecontroller(IEmployeeRepository employeeRepository)
        {
			EmployeeRepository = employeeRepository;
		}

		public IEmployeeRepository EmployeeRepository { get; }

		public IActionResult Index()
		{
			return View();
		}
	}
}
