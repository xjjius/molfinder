﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Models
{
    class Phone
    {
        public int TypeCode { get; set; } // 1=phone, 2=mobile, 3=fax
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
