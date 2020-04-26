using System.Collections.Generic;

namespace Szhchem.Data
{
    public class MolNameGroup
    {
        public int NameType { get; set; }
        public List<MolName> MolNames { get; set; } = new List<MolName>();
    }
}