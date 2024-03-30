using AspNetCoreHero.ToastNotification.Abstractions;
using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.PLL.interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FirstProject_Mvc.Pl.Controllers
{
	//  [ValidateAntiForgeryToken]
	public class Departmentcontroller : Controller
	{
		public Departmentcontroller(IdepartmentRepository idepartmentRepository, INotyfService notyf)
		{
			IdepartmentRepository = idepartmentRepository;
			Notyf = notyf;
		}

		public IdepartmentRepository IdepartmentRepository { get; }
		public INotyfService Notyf { get; }

		public IActionResult Index(string inputData)
		{
			if (string.IsNullOrEmpty(inputData))
			{
				var result = IdepartmentRepository.GetAll();
				return View(result);
			}
			else
			{
				var emp = IdepartmentRepository.GetDepartmentsByName(inputData.ToLower());
				return View(emp);
			}

		}

		//      [HttpPost]
		//      public IActionResult index(string inputData)
		//      {
		//          if(inputData != null)
		//          {
		//		var emp = IdepartmentRepository.GetDepartmentsByName(inputData.ToLower());
		//		return View(emp);
		//	}
		//          else
		//          {
		//		var result = IdepartmentRepository.GetAll();
		//		return View(result);
		//	}
		//          return View();

		//}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Department department)
		{
			if (ModelState.IsValid)
			{
				var count = IdepartmentRepository.Add(department);
				if (count > 0)
				{
					//TempData["Message"] = "Department is created SuccessFully ";
					// ToastNotification.AddSuccessToastMessage("Department is created SuccessFully");
					Notyf.Success("Department is created SuccessFully");
					return RedirectToAction(nameof(Index));
				}
			}
			return View(department);
		}



		public ActionResult Details(int? id, string ViewName = "Details")
		{
			if (id is null)
			{
				return BadRequest();
			}

			var department = IdepartmentRepository.Get(id.Value);
			return View(department);
		}

		[HttpGet]
		public ActionResult Edit(int? id)
		{

			///if (id is null)
			///{
			///    return BadRequest();
			///}
			///
			///var department = IdepartmentRepository.Get(id.Value);
			///return View(department);


			return Details(id, "Edit");

		}

		[HttpPost]
		public ActionResult Edit(Department de)
		{
			if (de is null)
			{
				return BadRequest();
			}
			else
			{
				Notyf.Success("Department is Update SuccessFully");
				IdepartmentRepository.Update(de);
				return RedirectToAction(nameof(Index));
			}



		}


		[HttpGet]
		public ActionResult Delete(int? id)
		{
			return Details(id, "Delete");
		}
		public IActionResult Delete(Department department)
		{
			IdepartmentRepository.Delete(department);
			Notyf.Error("Department is Update SuccessFully");
			return RedirectToAction(nameof(Index));

		}

	}

}
