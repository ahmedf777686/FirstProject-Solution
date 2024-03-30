using FirstProject_Mvc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.interfaces
{
	public interface IGenericReposiory<T> where T : class
	{
		public IEnumerable<T> GetAll();

		public T Get(int id);

		public void Delete(T item);
		public void Update(T item);
		public void Add(T item);

	}
}
