using FirstProject_Mvc.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.DAL.Data.Configurations
{

	public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.Property(e => e.Name).IsRequired();
			builder.Property(e => e.Address).IsRequired();

			builder.Property(e => e.Salary).HasColumnType("decimal(12,2)");

			builder.Property(e => e.Gender).HasConversion(

				(gender) =>gender.ToString(),
				(genderstr) => (Gender) Enum.Parse(typeof(Gender), genderstr ,true)

				);

			
		}
	}
}
