using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.Pl.ViewsModels;
using FirstProject_Mvc.PLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FirstProject_Mvc.Pl.Controllers
{
	public class Employeecontroller : Controller
	{


		public Employeecontroller(IMapper mapper,IEmployeeRepository employeeRepository ,IdepartmentRepository idepartmentRepository,INotyfService notyf)
		{
			Mapper = mapper;
			_EmployeeRepository = employeeRepository;
			IdepartmentRepository = idepartmentRepository;
			Notyf = notyf;
		}

		public IMapper Mapper { get; }
		public IEmployeeRepository _EmployeeRepository { get; }
		public IdepartmentRepository IdepartmentRepository { get; }
		public INotyfService Notyf { get; }

		// index
		public IActionResult Index(string inputData)
		{
			if (string.IsNullOrEmpty(inputData))
			{
			
				var result = _EmployeeRepository.GetAll();
				var Emp = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(result);
				return View(Emp);
			}
			else
			{

			var result =_EmployeeRepository.GetEmployeeByName(inputData);
				var Emp = Mapper.Map<IQueryable<Employee>, IQueryable<EmployeeViewModel>>(result);
				return View(Emp);
			}
			
		}


		// create Employee
		public IActionResult Create()
		{
			ViewData["Department"] = IdepartmentRepository.GetAll();
			return View();
		}
		[HttpPost]
		public IActionResult Create(EmployeeViewModel employeeVM)
		{
			if (ModelState.IsValid)
			{
				var emp = Mapper.Map<EmployeeViewModel, Employee>(employeeVM);
				var Count = _EmployeeRepository.Add(emp);
				if (Count > 0)
				{
					Notyf.Success("Employee is created SuccessFully", 2);
					return RedirectToAction(nameof(Index));
				}
			}

			return View(employeeVM);
		}

		public IActionResult Details(int id)
		{
			ViewData["Department"] = IdepartmentRepository.GetAll();
			
			var Emp = _EmployeeRepository.Get(id);
			var Res = Mapper.Map<Employee, EmployeeViewModel>(Emp);
			return View(Res);
		}


		// Edit Employee
		public IActionResult Edit(int id)
		{
			ViewData["Department"] = IdepartmentRepository.GetAll();
			var res = _EmployeeRepository.Get(id);
			var Emp = Mapper.Map<Employee, EmployeeViewModel>(res);
			return View(Emp);
		}

		[HttpPost]


		public IActionResult Edit(EmployeeViewModel employeeVm)
		{
			if (ModelState.IsValid)
			{
				var emp = Mapper.Map<EmployeeViewModel, Employee>(employeeVm);
				var res = _EmployeeRepository.Update(emp);

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
			var emp = Mapper.Map<Employee, EmployeeViewModel>(res);
			return View(emp);
		}

		[HttpPost]
		public IActionResult Delete(EmployeeViewModel  employeeVm)
		{
			if (employeeVm is null)
			{
				return BadRequest();
			}
			else
			{
				var Emp = Mapper.Map<EmployeeViewModel, Employee>(employeeVm);
				_EmployeeRepository.Delete(Emp);
				Notyf.Error("Employee is Delete SuccessFully");
				return RedirectToAction(nameof(Index));
				
			}

		}








	}
}

