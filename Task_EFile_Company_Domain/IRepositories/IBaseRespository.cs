using System;
using System.Collections.Generic;
using System.Text;

namespace Task_EFile_Company_Domain.IRepositories
{
    public interface IBaseRespository<T> where T : class
    {
        IEnumerable<T> GetAllData();

        void Add(T entity);

        T GetById(int? id);

        void Edit(T entity);

        bool Delete(T entity);

    }
}
