using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_EFile_Company.Models
{
    public class ViewModel_UserLogin
    {
        public int Id { get; set; }

        [Required,StringLength(20)]
        public string UserName { get; set; }

        [Required, StringLength(20)]
        public string Password { get; set; }
    }
}
