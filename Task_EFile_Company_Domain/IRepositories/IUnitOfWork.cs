using System;
using System.Collections.Generic;
using System.Text;

namespace Task_EFile_Company_Domain.IRepositories
{
    public interface IUnitOfWork
    {
        IContactRepository contactRepository { get; }
        IUserLoginRepository userLoginRepository { get; }

        bool SaveData();
    }
}
