using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.PLL.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject_Mvc.Pl.Controllers
{
	public class Employeecontroller : Controller
	{


		public Employeecontroller(IEmployeeRepository employeeRepository)
		{
			_EmployeeRepository = employeeRepository;
		}

		public IEmployeeRepository _EmployeeRepository { get; }

		// index
		public IActionResult Index()
		{
			var result = _EmployeeRepository.GetAll();
			return View(result);
		}


		// create Employee
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			if (ModelState.IsValid)
			{
				var Count = _EmployeeRepository.Add(employee);
				if (Count > 0)
				{
					return RedirectToAction(nameof(Index));
				}
			}

			return View(employee);
		}

		public IActionResult Details(int id)
		{
			var Emp = _EmployeeRepository.Get(id);

			return View(Emp);
		}


		// Edit Employee
		public IActionResult Edit(int id)
		{
			var res = _EmployeeRepository.Get(id);
			return View(res);
		}

		[HttpPost]
		public IActionResult Edit(Employee employee)
		{
			if (ModelState.IsValid)
			{
				var res = _EmployeeRepository.Update(employee);
				return RedirectToAction(nameof(Index));
			}

			return BadRequest();
		}


		[HttpGet]
		public IActionResult Delete(int id)
		{
			var res =_EmployeeRepository.Get(id);
			return View(res);
		}

		[HttpPost]
		public IActionResult Delete(Employee employee)
		{
			if (employee is null)
			{
				return BadRequest();
			}
			else
			{
				_EmployeeRepository.Delete(employee);
				return RedirectToAction(nameof(Index));
			}

		}








	}
}

