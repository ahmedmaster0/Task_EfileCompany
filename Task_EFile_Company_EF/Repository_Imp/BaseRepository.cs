using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_EFile_Company_Domain.IRepositories;
using Task_EFile_Company_Domain.Models;

namespace Task_EFile_Company_EF.Repository_Imp
{
    public class BaseRepository<T> : IBaseRespository<T> where T : class
    {
        protected readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(T entity)
        {
           if( _context.Set<T>().Remove(entity) != null)
            {
                return true;
            }
            return false;
        }

        public void Edit(T entity)
        {
            _context.Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAllData()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int? id)
        {
           return _context.Set<T>().Find(id);
        }
    }
}
