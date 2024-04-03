using FirstProject_Mvc.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace FirstProject_Mvc.Pl.ViewsModels
{
	public class EmployeeViewModel
	{
		public int id { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Name is Required !")]
		[MinLength(5, ErrorMessage = "Min length of Name  is 5 chars")]

		public string Name { get; set; }
		[Range(22, 34)]
		public int Age { get; set; }

		public string Address { get; set; }

		[DataType(DataType.Currency)]
		public decimal Salary { get; set; }
		[Display(Name = "Is Active")]
		public bool IsActive { get; set; }
		[EmailAddress]

		public string Email { get; set; }
		[Display(Name = "Phone Number")]
		[Phone]
		public string PhoneNumber { get; set; }
		[Display(Name = "Hiring Date")]

		public DateTime HiringDate { get; set; }

		
		public Gender Gender { get; set; }

		public EmpType EmpType { get; set; }

		public int? DepartmentId { get; set; }
		public virtual Department Department { get; set; }

        public string ImageName { get; set; }

        public  IFormFile  Image { get; set; }
    }
}
