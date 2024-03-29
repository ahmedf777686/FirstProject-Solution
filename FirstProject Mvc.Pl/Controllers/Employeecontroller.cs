using AspNetCoreHero.ToastNotification.Abstractions;
using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.PLL.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject_Mvc.Pl.Controllers
{
	public class Employeecontroller : Controller
	{


		public Employeecontroller(IEmployeeRepository employeeRepository ,IdepartmentRepository idepartmentRepository,INotyfService notyf)
		{
			_EmployeeRepository = employeeRepository;
			IdepartmentRepository = idepartmentRepository;
			Notyf = notyf;
		}

		public IEmployeeRepository _EmployeeRepository { get; }
		public IdepartmentRepository IdepartmentRepository { get; }
		public INotyfService Notyf { get; }

		// index
		public IActionResult Index()
		{
			var result = _EmployeeRepository.GetAll();
			return View(result);
		}


		// create Employee
		public IActionResult Create()
		{
			ViewData["Department"] = IdepartmentRepository.GetAll();
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
					Notyf.Success("Employee is created SuccessFully", 2);
					return RedirectToAction(nameof(Index));
				}
			}

			return View(employee);
		}

		public IActionResult Details(int id)
		{
			ViewData["Department"] = IdepartmentRepository.GetAll();
			var Emp = _EmployeeRepository.Get(id);

			return View(Emp);
		}


		// Edit Employee
		public IActionResult Edit(int id)
		{
			ViewData["Department"] = IdepartmentRepository.GetAll();
			var res = _EmployeeRepository.Get(id);
			return View(res);
		}

		[HttpPost]
		public IActionResult Edit(Employee employee)
		{
			if (ModelState.IsValid)
			{
				var res = _EmployeeRepository.Update(employee);
				Notyf.Information("Employee is Update SuccessFully");
				return RedirectToAction(nameof(Index));
			}

			return BadRequest();
		}


		[HttpGet]
		public IActionResult Delete(int id)
		{
			ViewData["Department"] = IdepartmentRepository.GetAll();

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
				Notyf.Error("Employee is Delete SuccessFully");
				return RedirectToAction(nameof(Index));
				
			}

		}








	}
}

