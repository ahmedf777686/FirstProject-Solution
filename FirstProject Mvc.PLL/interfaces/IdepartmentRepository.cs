﻿using FirstProject_Mvc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.interfaces
{
    public interface IdepartmentRepository : IGenericReposiory<Department>
    {
        //public IEnumerable<Department> GetAll();

        //public Department Get(int id);

        //public int Delete(Department department);
        //public int Update(Department department);
        //public int Add(Department department);
        public IEnumerable<Department> GetDepartmentsByName(string inputData);

    }
}
