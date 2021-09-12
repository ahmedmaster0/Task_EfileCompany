using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_EFile_Company.Models
{
    public class ViewModel_Contact
    {
        public int Id { get; set; }

        [Required,StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(11)]
        public string Phone { get; set; }
        [Required, StringLength(200)]
        public string Address { get; set; }
        [ StringLength(250)]
        public string Notes { get; set; }
        public bool FlagEdting { get; set; }
    }
}
