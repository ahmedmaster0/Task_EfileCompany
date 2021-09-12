using System;
using System.Collections.Generic;
using System.Text;
using Task_EFile_Company_Domain.IRepositories;
using Task_EFile_Company_Domain.Models;

namespace Task_EFile_Company_EF.Repository_Imp
{
    public class UserLoginRepository : BaseRepository<UserLogin>,IUserLoginRepository
    {
        public UserLoginRepository(ApplicationContext context):base(context)
        {

        }
    }
}
