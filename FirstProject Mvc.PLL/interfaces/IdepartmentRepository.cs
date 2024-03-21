using FirstProject_Mvc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.interfaces
{
    internal interface IdepartmentRepository
    {
        public IEnumerable<Department> GetAll();

        public Department Get(int id);

        public int Delete(Department department);
        public int Update(Department department);
        public int Add(Department department);


    }
}
