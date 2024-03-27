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
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.ID).UseIdentityColumn(10, 10);
            //builder.Property(d => d.Name).IsRequired().HasColumnType("varchar");
            //builder.Property(d => d.Code).IsRequired().HasColumnType("varchar");
        }
    }

}
