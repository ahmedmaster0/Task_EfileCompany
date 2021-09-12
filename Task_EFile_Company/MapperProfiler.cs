using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_EFile_Company.Models;
using Task_EFile_Company_Domain.Models;

namespace Task_EFile_Company
{
    public class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            CreateMap<ViewModel_Contact, Contact>().ReverseMap();
        }
    }
}
