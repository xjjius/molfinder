﻿using OpenBabel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szhchem.Chemistry
{
    public class OpenbabelBase
    {
        protected readonly OBConversion conv = new OBConversion();

        protected void SetMoleculeFromSmiles(OBMol mol, string smiles)
        {
            conv.SetInFormat("smi");
            conv.ReadString(mol, smiles);
        }

        protected void SetMoleculeFromMolFile(OBMol mol, string molFile)
        {
            conv.SetInFormat("mol");
            conv.ReadString(mol, molFile);
        }

        public void SetMoleculeFromString(OBMol mol, string molString)
        {
            if (molString.TrimEnd().EndsWith("M  END"))
            {
                SetMoleculeFromMolFile(mol, molString);
            }
            else if (!molString.Trim().Contains(" "))
            {
                SetMoleculeFromSmiles(mol, molString);
            }
            else
            {
                throw new Exception("Wrong chemical file format !!");
            }
        }
    }
}
