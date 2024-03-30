using FirstProject_Mvc.DAL.Data;
using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.PLL.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.PLL.Repository
{
	public class GenericRepoisory<T> : IGenericReposiory<T> where T : class
	{
		private  readonly ApplicationDbContext _dbContext;

		public GenericRepoisory(ApplicationDbContext dbContext)
        {
			_dbContext = dbContext;
		}
        public void Add(T item)
		{
			_dbContext.Add(item);
		
		}

		public void Delete(T item)
		{
			_dbContext.Remove(item);
			
		}

		public T Get(int id)
		{
			return _dbContext.Set<T>().Find(id);

		}

		public IEnumerable<T> GetAll()
			
		{
			if(typeof(T) == typeof(Employee))
			{
				return (IEnumerable<T>)_dbContext.Employee.Include(E => E.Department);
			}
			return _dbContext.Set<T>().ToList();
		}

		public void Update(T item)
		{
			_dbContext.Update(item);
			
		}
	}
}
