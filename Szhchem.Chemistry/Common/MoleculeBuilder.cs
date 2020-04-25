﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBabel;

namespace Szhchem.Chemistry
{
    public class MoleculeBuilder : OpenbabelBase
    {
        public MoleculeBuilder() : base() { }

        public MoleculeBuilder(string molString)
        {
            SetMoleculeFromString(mol, molString);
        }
        
        private readonly OBMol mol = new OBMol();

        public MoleculeBase BuildMoleculeBase()
        {
            return new MoleculeBase
            {
                MolStat = GetMolStat(),
                Fp2 = GetFP("FP2"),
                Fp4 = GetFP("FP4"),
                Mass = mol.GetMolWt(),
                Formula = mol.GetFormula(),
                ExactMass = mol.GetExactMass(),
                Charge = (short)mol.GetTotalCharge(),
                InChI = GetInChI(),
                InChIKey = GetInChIKey(),
                MolFile = GetMolFileText(),
                IsomericSmiles = GetISOMericSmiles().TrimEnd(),
                CanonicSmiles = GetCanonicalSmiles().TrimEnd(),
            };
        }

        public string GetMolFileText()
        {
            conv.SetOutFormat("mol");
            return conv.WriteString(mol);
        }

        public string GetISOMericSmiles()
        {
            conv.SetOutFormat("smi");
            return conv.WriteString(mol);
        }

        public string GetCanonicalSmiles()
        {
            conv.SetOutFormat("CAN");
            return conv.WriteString(mol);
        }

        public string GetInChI(bool IsFullFormat = true)
        {
            conv.SetOutFormat("inchi");

            string s = conv.WriteString(mol);

            if (!IsFullFormat)
            {
                if (s.StartsWith("InChI="))
                {
                    s = s.TrimStart(("InChI=").ToCharArray());
                }
            }
            return s.Replace("\n", "");
        }

        public string GetInChIKey()
        {
            conv.SetOutFormat("inchi");
            conv.AddOption("K");

            string _s = conv.WriteString(mol);

            return _s.Replace("\n", "");
        }

        public string GetFormula()
        {
            return mol.GetFormula();
        }

        public double GetWeight()
        {
            return mol.GetMolWt();
        }

        public double GetExactMass()
        {
            return mol.GetExactMass();
        }

        public double GetEnergy()
        {
            return mol.GetEnergy();
        }

        public int GetTotalCharge()
        {
            return mol.GetTotalCharge();
        }

        public MolStat GetMolStat()
        {
            /* 统计原子 */
            uint _numAtoms = mol.NumAtoms(); //所有原子总数
            uint _numHvyAtoms = mol.NumHvyAtoms(); //所有除去氢原子的原子总数
            int _totalCharge = mol.GetTotalCharge(); //总电荷数

            int n_C = 0;    // number of carbon atoms 碳原子总数
            int n_C1 = 0;   // number of carbon atoms with sp1 hybridization sp1杂化的碳原子数
            int n_C2 = 0;   // number of carbon atoms with sp1 hybridization sp2杂化的碳原子数
            int n_CHB1p = 0;// number of carbon atoms with at least 1 bond to a hetero atom 至少连接一个杂原子的碳原子数
            int n_CHB2p = 0;// number of carbon atoms with at least 2 bonds to a hetero atom 至少连接两个个杂原子的碳原子数
            int n_CHB3p = 0;// number of carbon atoms with at least 3 bonds to a hetero atom 至少连接三个杂原子的碳原子数
            int n_CHB4 = 0; // number of carbon atoms with 4 bonds to a hetero atom 连接了4个杂原子的碳原子数
            int n_O = 0;    // number of oxygen atoms 氧原子数
            int n_O2 = 0;   // number of sp2-hybridized oxygen atoms sp2杂化的氧原子数
            int n_O3 = 0;   // number of sp3-hybridized oxygen atoms sp3杂化的氧原子数
            int n_N = 0;    // number of nitrogen atoms 氮原子数
            int n_N1 = 0;   // number of sp-hybridized nitrogen atoms sp杂化的氮原子数
            int n_N2 = 0;   // number of sp2-hybridized nitrogen atoms sp2杂化的氮原子数
            int n_N3 = 0;   // number of sp3-hybridized nitrogen atoms sp3杂化的氮原子数
            int n_S = 0;    // number of sulfur atoms 硫原子数
            int n_SeTe = 0; // total number of selenium and tellurium atoms 硒和碲原子的数目
            int n_F = 0;    // number of fluorine atoms 氟原子的数目
            int n_Cl = 0;   // number of chlorine atoms 氯原子的数目
            int n_Br = 0;   // number of bromine atoms 溴原子的数目
            int n_I = 0;    // number of iodine atoms 碘原子的数目
            int n_P = 0;    // number of phosphorus atoms 磷原子的数目
            int n_B = 0;    // number of boron atoms 硼原子的数目
            int n_Met = 0;  // total number of metal atoms 金属原子的数目
            int n_X = 0;    // total number of "other" atoms (not listed above) and halogens 其他原子的数目，除了以上列出的之外。

            for (int i = 1; i <= _numAtoms; i++)
            {
                OBAtom _atom = mol.GetAtom(i);
                uint _AtomicNum = _atom.GetAtomicNum();           //原子种类，周期表序号
                uint _hyb = _atom.GetHyb();                       //原子的杂化形态，1 for sp1,  2 for sp2, 3 for sp3
                uint _HeteroValence = _atom.GetHeteroValence();   //连接在这个原子上杂（非氢，碳）原子的数目
                //uint _HeteroValence = _atom.GetHeteroDegree();  //For openbabel 3.0

                if (_AtomicNum == 6) //碳原子
                {
                    n_C++;

                    switch (_hyb)
                    {
                        case 1:
                            n_C1++;
                            break;
                        case 2:
                            n_C2++;
                            break;
                        default:
                            break;
                    }

                    if (_HeteroValence >= 4)
                    {
                        n_CHB4++;
                    }

                    if (_HeteroValence >= 3)
                    {
                        n_CHB3p++;
                    }

                    if (_HeteroValence >= 2)
                    {
                        n_CHB2p++;
                    }

                    if (_HeteroValence >= 1)
                    {
                        n_CHB1p++;
                    }


                }
                else if (_AtomicNum == 8)
                {
                    n_O++;
                    switch (_hyb)
                    {
                        case 2:
                            n_O2++;
                            break;
                        case 3:
                            n_O3++;
                            break;
                        default:
                            break;
                    }
                }
                else if (_AtomicNum == 7)
                {
                    n_N++;
                    switch (_hyb)
                    {
                        case 1:
                            n_N1++;
                            break;
                        case 2:
                            n_N2++;
                            break;
                        case 3:
                            n_N3++;
                            break;
                        default:
                            break;
                    }
                }
                else if (_AtomicNum == 16)
                {
                    n_S++;
                }
                else if (_AtomicNum == 34 || _AtomicNum == 52)
                {
                    n_SeTe++;
                }
                else if (_AtomicNum == 9)
                {
                    n_F++;
                }
                else if (_AtomicNum == 17)
                {
                    n_Cl++;
                }
                else if (_AtomicNum == 35)
                {
                    n_Br++;
                }
                else if (_AtomicNum == 53)
                {
                    n_I++;
                }
                else if (_AtomicNum == 15)
                {
                    n_P++;
                }
                else if (_AtomicNum == 5)
                {
                    n_B++;
                }
                else if ((_AtomicNum >= 3 && _AtomicNum <= 4) || (_AtomicNum >= 11 && _AtomicNum <= 13) || (_AtomicNum >= 19 && _AtomicNum <= 32) || (_AtomicNum >= 37 && _AtomicNum <= 51) || (_AtomicNum >= 55 && _AtomicNum <= 84) || (_AtomicNum >= 87))
                {
                    n_Met++;
                }

            }

            n_X = (int)_numHvyAtoms - n_B - n_C - n_Met - n_N - n_O - n_P - n_S - n_SeTe;

            /* 统计化学键 */

            uint _numBonds = mol.NumBonds(); //所有化学键的总数

            int n_b1 = 0;          // number of single bonds 单键的个数
            int n_b1_NoH = 0;      // number of none C-H single bonds 不含氢的单键个数
            int n_b2 = 0;          // number of double bonds 双键的个数
            int n_b3 = 0;          // number of triple bonds 三键的个数
            int n_bar = 0;         // number of aromatic bonds 芳香键的个数
            int n_C1O = 0;         // number of C-O single bonds 碳-氧单键的个数
            int n_C2O = 0;         // number of C=O double bonds 碳=氧双键的个数
            int n_CN = 0;          // number of C/N bonds (any type) 任何类型的碳氮键的个数
            int n_XY = 0;          // number of heteroatom/heteroatom bonds (any type) 任何类型的杂原子之间化学健的个数
            
            for (int i = 0; i < _numBonds; i++)
            {
                OBBond _bond = mol.GetBond(i);

                OBAtom _beginAtom = _bond.GetBeginAtom();
                OBAtom _endAtom = _bond.GetEndAtom();

                uint _beginAtomAtomicNum = _beginAtom.GetAtomicNum();
                uint _endAtomAtomicNum = _endAtom.GetAtomicNum();

                if (_bond.IsSingle())  //Replace IsSingle() method in Openbabel 3.0
                {
                    n_b1++;
                    if (_beginAtomAtomicNum != 1 && _endAtomAtomicNum != 1)
                    {
                        n_b1_NoH++;
                    }
                }
                else if (_bond.IsDouble())  // Replace IsDouble() method in Openbabel 3.0
                {
                    n_b2++;
                }
                else if (_bond.IsTriple())  // Replace IsTriple() method in Openbabel 3.0
                {
                    n_b3++;
                }
                else if (_bond.IsAromatic())
                {
                    n_bar++;
                }

                if ((_beginAtomAtomicNum == 6 && _endAtomAtomicNum == 8) || (_beginAtomAtomicNum == 8 && _endAtomAtomicNum == 6))
                {
                    uint _bondOrder = _bond.GetBondOrder();

                    if (_bondOrder == 1)
                    {
                        n_C1O++;
                    }
                    else if (_bondOrder == 2)
                    {
                        n_C2O++;
                    }

                }
                else if ((_beginAtomAtomicNum == 6 && _endAtomAtomicNum == 7) || (_beginAtomAtomicNum == 7 && _endAtomAtomicNum == 6))
                {
                    n_CN++;
                }
                else if (_beginAtomAtomicNum != 6 && _endAtomAtomicNum != 6)
                {
                    n_XY++;
                }
            }

            /* 统计环 */
            #region 统计环

            VectorpRing _SSSR = mol.GetSSSR();
                        
            int n_r3 = 0;   // number of 3-membered rings 3元环个数
            int n_r4 = 0;   // number of 4-membered rings 4元环个数
            int n_r5 = 0;   // number of 5-membered rings 5元环个数
            int n_r6 = 0;   // number of 6-membered rings 6元环个数
            int n_r7 = 0;   // number of 7-membered rings 7元环个数
            int n_r8 = 0;   // number of 8-membered rings 8元环个数
            int n_r9 = 0;   // number of 9-membered rings 9元环个数
            int n_r10 = 0;  // number of 10-membered rings 10元环个数
            int n_r11 = 0;  // number of 11-membered rings 11元环个数
            int n_r12 = 0;  // number of 12-membered rings 12元环个数
            int n_r13p = 0; // number of 13-membered or larger rings 13元环或者更大的环的个数
            int n_rN = 0;   // number of rings containing nitrogen (any number) 含氮环的个数
            int n_rN1 = 0;  // number of rings containing 1 nitrogen atom 含一个氮原子的环的个数
            int n_rN2 = 0;  // number of rings containing 2 nitrogen atoms 含两个个氮原子的环的个数
            int n_rN3p = 0; // number of rings containing 3 or more nitrogen atoms 含三个或以上个氮原子的环的个数
            int n_rO = 0;   // number of rings containing oxygen (any number) 含氧环的个数
            int n_rO1 = 0;  // number of rings containing 1 oxygen atom 含一个氧原子的环的个数
            int n_rO2p = 0; // number of rings containing 2 or more oxygen atoms 含三个或以上个氧原子的环的个数
            int n_rS = 0;   // number of rings containing sulfur (any number) 含硫环的个数
            int n_rX = 0;   // number of heterocycles (any type) 杂环的个数
            int n_rar = 0;  // number of aromatic rings (any type) 芳香环的个数

            if (_SSSR.Count != 0 || _SSSR != null)
            {
                foreach (OBRing _ring in _SSSR)
                {
                    uint _ringSize = _ring.Size();

                    if (_ringSize == 3)
                    {
                        n_r3++;
                    }
                    else if (_ringSize == 4)
                    {
                        n_r4++;
                    }
                    else if (_ringSize == 5)
                    {
                        n_r5++;
                    }
                    else if (_ringSize == 6)
                    {
                        n_r6++;
                    }
                    else if (_ringSize == 7)
                    {
                        n_r7++;
                    }
                    else if (_ringSize == 8)
                    {
                        n_r8++;
                    }
                    else if (_ringSize == 9)
                    {
                        n_r9++;
                    }
                    else if (_ringSize == 10)
                    {
                        n_r10++;
                    }
                    else if (_ringSize == 11)
                    {
                        n_r11++;
                    }
                    else if (_ringSize == 12)
                    {
                        n_r12++;
                    }
                    else if (_ringSize >= 13)
                    {
                        n_r13p++;
                    }

                    if (_ring.IsAromatic())
                    {
                        n_rar++;
                    }

                    VectorInt _pathes = _ring._path;

                    int _ct_N = 0;
                    int _ct_O = 0;
                    int _ct_S = 0;

                    bool _isRingX = false;
                    foreach (int _p in _pathes)
                    {
                        OBAtom _atom = mol.GetAtom(_p);

                        uint _AtomicNum = _atom.GetAtomicNum();

                        if (_AtomicNum == 7) //N原子
                        {
                            _ct_N++;
                        }
                        else if (_AtomicNum == 8) //O原子
                        {
                            _ct_O++;
                        }
                        else if (_AtomicNum == 16) //S原子
                        {
                            _ct_S++;
                        }

                        if (_AtomicNum != 6)
                        {
                            _isRingX = true;
                        }
                    }

                    if (_ct_N == 1)
                    {
                        n_rN1++;
                    }
                    else if (_ct_N == 2)
                    {
                        n_rN2++;
                    }
                    else if (_ct_N >= 3)
                    {
                        n_rN3p++;
                    }

                    n_rN = n_rN1 + n_rN2 + n_rN3p;

                    if (_ct_O == 1)
                    {
                        n_rO1++;
                    }
                    else if (_ct_O >= 2)
                    {
                        n_rO2p++;
                    }

                    n_rO = n_rO1 + n_rO2p;

                    if (_ct_S >= 1)
                    {
                        n_rS++;
                    }

                    if (_isRingX)
                    {
                        n_rX++;
                    }

                }
            }

            #endregion

            // 统计数字映射成MolStat对象
            MolStat stat = new MolStat
            {
                // General info
                AtomsCount = (int)_numAtoms,
                HeavyAtomsCount = (int)_numHvyAtoms,
                TotalCharge = _totalCharge,
                // Atoms info
                N_B = n_B,
                N_Br = n_Br,
                N_C = n_C,
                N_C1 = n_C1,
                N_C2 = n_C2,
                N_CHB1p = n_CHB1p,
                N_CHB2p = n_CHB2p,
                N_CHB3p = n_CHB3p,
                N_CHB4 = n_CHB4,
                N_Cl = n_Cl,
                N_F = n_F,
                N_I = n_I,
                N_Met = n_Met,
                N_N = n_N,
                N_N1 = n_N1,
                N_N2 = n_N2,
                N_N3 = n_N3,
                N_O = n_O,
                N_O2 = n_O2,
                N_O3 = n_O3,
                N_P = n_P,
                N_S = n_S,
                N_SeTe = n_SeTe,
                N_X = n_X,
                // Bonds info
                BondsCount = (int)_numBonds,
                N_b1 = n_b1,
                N_b1_NoH = n_b1_NoH,
                N_b2 = n_b2,
                N_b3 = n_b3,
                N_bar = n_bar,
                N_C1O = n_C1O,
                N_C2O = n_C2O,
                N_CN = n_CN,
                N_XY = n_XY,
                // Rings info
                RingsCount = _SSSR.Count,
                N_r10 = n_r10,
                N_r11 = n_r11,
                N_r12 = n_r12,
                N_r13p = n_r13p,
                N_r3 = n_r3,
                N_r4 = n_r4,
                N_r5 = n_r5,
                N_r6 = n_r6,
                N_r7 = n_r7,
                N_r8 = n_r8,
                N_r9 = n_r9,
                N_rar = n_rar,
                N_rN = n_rN,
                N_rN1 = n_rN1,
                N_rN2 = n_rN2,
                N_rN3p = n_rN3p,
                N_rO = n_rO,
                N_rO1 = n_rO1,
                N_rO2p = n_rO2p,
                N_rS = n_rS,
                N_rX = n_rX
            };

            return stat;
        }

        /// <summary>
        /// 生成指纹码
        /// </summary>
        /// <param name="FpType">FP2 or FP4</param>
        /// <returns></returns>
        private long[] GetFP(string fpType)
        {
            VectorUInt _fp = new VectorUInt();
            OBFingerprint _FPC = OBFingerprint.FindFingerprint(fpType);
            _FPC.GetFingerprint(mol, _fp);

            if ((fpType == "FP2" && _fp.Count != 32) || (fpType == "FP4" && _fp.Count != 16))
            {
                throw new Exception("获取FP错误，请确认OpenBabel GUI已正确安装安装, 环境变量BABEL_DATADIR在当前用户下已经正确设置");
            }
            
            long[] fp = new long[_fp.Count];

            for (int i = 0; i < _fp.Count; i++)
            {
                fp[i] = _fp[i]; // uint type automatically cast to long type
            }

            return fp;
        }
    }
}
