using System;
using System.Collections.Generic;
using System.Text;

namespace Task_EFile_Company_Domain.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Notes { get; set; }

        public bool FlagEdting { get; set; }
    }
}
