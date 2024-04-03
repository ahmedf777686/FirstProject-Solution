using Microsoft.AspNetCore.Http;
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
		[MaxLength(50)]
		

		public string Name { get; set; }
		
		public int Age { get; set; }

		public string Address { get; set; }

		public decimal Salary { get; set; }
	
		public bool IsActive { get; set; }
		
		public string Email { get; set; }
		
		public string PhoneNumber { get; set; }
		

		public DateTime HiringDate { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.Now;

		public Gender Gender { get; set; }

		public EmpType EmpType { get; set; }

		public int? DepartmentId { get; set; }
		public virtual Department Department { get; set; }

        public string ImageName { get; set; }
    }
}
