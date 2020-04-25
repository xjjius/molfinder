﻿using OpenBabel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szhchem.Chemistry
{
    /// <summary>
    /// 从openbabel 2.x 升级到 3.0.0的有一些API变动
    /// </summary>
    public static class Openbabel3UpgradeExtension
    {
        public static uint GetHeteroValence(this OBAtom atom)
        {
            return atom.GetHeteroDegree();
        }

        public static bool IsSingle(this OBBond bond)
        {
            return bond.GetBondOrder() == 1;
        }

        public static bool IsDouble(this OBBond bond)
        {
            return bond.GetBondOrder() == 2;
        }

        public static bool IsTriple(this OBBond bond)
        {
            return bond.GetBondOrder() == 3;
        }
    }
}
