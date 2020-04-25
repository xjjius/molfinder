using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Chemistry
{
    public class SDFSection
    {
        public string MolFile { get; set; }
        public List<SDFProperty> Properties { get; set; } = new List<SDFProperty>();
    }
}
