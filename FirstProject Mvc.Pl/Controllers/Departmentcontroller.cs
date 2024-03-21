using FirstProject_Mvc.PLL.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject_Mvc.Pl.Controllers
{
    public class Departmentcontroller : Controller
    {
        public Departmentcontroller(IdepartmentRepository idepartmentRepository)
        {
            IdepartmentRepository = idepartmentRepository;
        }

        public IdepartmentRepository IdepartmentRepository { get; }

        public IActionResult Index()
        {
            var result = IdepartmentRepository.GetAll();
            return View(result);
        }
    }
}
