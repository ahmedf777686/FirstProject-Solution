using FirstProject_Mvc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.interfaces
{
	public interface IGenericReposiory<T> where T : Modlebase
	{
		public IEnumerable<T> GetAll();

		public T Get(int id);

		public int Delete(T item);
		public int Update(T item);
		public int Add(T item);

	}
}
