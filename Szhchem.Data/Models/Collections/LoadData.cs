using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    public class LoadData
    {
        public bool IsNewStructure { get; set; } = false;
        public Molecule Molecule { get; set; } = new Molecule();
        public Substance Substance { get; set; } = new Substance();
        public List<MolName> MolNames { get; set; } = new List<MolName>();
        public List<MolRegNo> MolRegNos { get; set; } = new List<MolRegNo>();
        public List<Property> Properties { get; set; } = new List<Property>();
        public List<Reference> References { get; set; } = new List<Reference>();
    }
}
