using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Chemistry
{
    public class MoleculeBase
    {
        public string MolFile { get; set; }
        public string IsomericSmiles { get; set; }
        public string CanonicSmiles { get; set; }
        public double ExactMass { get; set; }
        public double Mass { get; set; }
        public string Formula { get; set; }
        public short Charge { get; set; }
        public string InChI { get; set; }
        public string InChIKey { get; set; }
        public MolStat MolStat { get; set; } = new MolStat();
        public long[] Fp4 { get; set; } = new long[16];
        public long[] Fp2 { get; set; } = new long[32];
    }
}
