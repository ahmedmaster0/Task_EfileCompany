using System;
using System.Collections.Generic;
using System.Text;
using Task_EFile_Company_Domain.IRepositories;
using Task_EFile_Company_EF.Repository_Imp;

namespace Task_EFile_Company_EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
      
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

      
        public IContactRepository contactRepository => new ContactRepository(_context);

        public IUserLoginRepository userLoginRepository => new UserLoginRepository(_context);

        public bool SaveData()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
