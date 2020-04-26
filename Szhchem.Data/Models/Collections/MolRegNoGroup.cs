using System.Collections.Generic;

namespace Szhchem.Data
{
    public class MolRegNoGroup
    {
        public int RegType { get; set; }
        public List<MolRegNo> MolRegNos { get; set; } = new List<MolRegNo>();
    }
}