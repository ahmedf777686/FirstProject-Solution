using FirstProject_Mvc.DAL.Data;
using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.PLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.Repository
{
	public class GenericRepoisory<T> : IGenericReposiory<T> where T : Modlebase
	{
		private  readonly ApplicationDbContext _dbContext;

		public GenericRepoisory(ApplicationDbContext dbContext)
        {
			_dbContext = dbContext;
		}
        public int Add(T item)
		{
			_dbContext.Add(item);
			return _dbContext.SaveChanges();
		}

		public int Delete(T item)
		{
			_dbContext.Remove(item);
			return _dbContext.SaveChanges();
		}

		public T Get(int id)
		{
			return _dbContext.Set<T>().Find();

		}

		public IEnumerable<T> GetAll()
		{
			return _dbContext.Set<T>().ToList();
		}

		public int Update(T item)
		{
			_dbContext.Update(item);
			return _dbContext.SaveChanges();
		}
	}
}
