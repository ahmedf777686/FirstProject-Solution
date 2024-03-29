using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.DAL.Models
{
	 
	public enum Gender
	{
		[EnumMember(Value = "Male")]

		Male = 1,
		[EnumMember(Value = "Female")]
		Female
	}
	public enum EmpType
	{
		FullTime = 1,
		PartTime
	}

	public class Employee 
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

		public DateTime CreationDate { get; set; }

		public Gender Gender { get; set; }

		public EmpType EmpType { get; set; }

		public int? DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
