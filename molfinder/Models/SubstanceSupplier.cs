using System;
using Szhchem.Data;

namespace molfinder.Models
{
    public class SubstanceSupplier
    {
        public Company Company { get; set; } = new Company();
        public long SubstanceID { get; set; }
        public string ExtUrl { get; set; }
        public string ExtID { get; set; }
    }
}