using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEDMobile
{
    public class Student
    {
        [PrimaryKey]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}


