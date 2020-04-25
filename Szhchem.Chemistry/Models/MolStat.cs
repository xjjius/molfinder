using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Chemistry
{
    public class MolStat
    {
        /// <summary>
        /// 所有原子总数
        /// </summary>
        public int AtomsCount { get; set; } = 0;

        /// <summary>
        /// 所有除去氢原子的原子总数
        /// </summary>
        public int HeavyAtomsCount { get; set; } = 0;

        /// <summary>
        /// 总化学价
        /// </summary>
        public int TotalCharge { get; set; } = 0;

        /// <summary>
        /// 碳原子总数
        /// </summary>
        public int N_C { get; set; } = 0;

        /// <summary>
        /// sp1杂化的碳原子数
        /// </summary>
        public int N_C1 { get; set; } = 0;

        /// <summary>
        /// sp2杂化的碳原子数
        /// </summary>
        public int N_C2 { get; set; } = 0;

        /// <summary>
        /// 至少连接1个杂原子的碳原子数
        /// </summary>
        public int N_CHB1p { get; set; } = 0;

        /// <summary>
        /// 至少连接2个杂原子的碳原子数
        /// </summary>
        public int N_CHB2p { get; set; } = 0;

        /// <summary>
        /// 至少连接3个杂原子的碳原子数
        /// </summary>
        public int N_CHB3p { get; set; } = 0;

        /// <summary>
        /// 连接4个杂原子的碳原子数
        /// </summary>
        public int N_CHB4 { get; set; } = 0;

        /// <summary>
        /// 氧原子数
        /// </summary>
        public int N_O { get; set; } = 0;

        /// <summary>
        /// sp2杂化的氧原子数
        /// </summary>
        public int N_O2 { get; set; } = 0;

        /// <summary>
        /// sp3杂化的氧原子数
        /// </summary>
        public int N_O3 { get; set; } = 0;

        /// <summary>
        /// 氮原子数
        /// </summary>
        public int N_N { get; set; } = 0;

        /// <summary>
        /// sp1杂化的氮原子数
        /// </summary>
        public int N_N1 { get; set; } = 0;

        /// <summary>
        /// sp2杂化的氮原子数
        /// </summary>
        public int N_N2 { get; set; } = 0;

        /// <summary>
        /// sp3杂化的氮原子数
        /// </summary>
        public int N_N3 { get; set; } = 0;

        /// <summary>
        /// 硫原子数
        /// </summary>
        public int N_S { get; set; } = 0;

        /// <summary>
        ///  硒和碲原子的数目
        /// </summary>
        public int N_SeTe { get; set; } = 0;

        /// <summary>
        /// 氟原子的数目
        /// </summary>
        public int N_F { get; set; } = 0;

        /// <summary>
        /// 氯原子的数目
        /// </summary>
        public int N_Cl { get; set; } = 0;

        /// <summary>
        /// 溴原子的数目
        /// </summary>
        public int N_Br { get; set; } = 0;

        /// <summary>
        /// 碘原子的数目
        /// </summary>
        public int N_I { get; set; } = 0;

        /// <summary>
        /// 磷原子的数目
        /// </summary>
        public int N_P { get; set; } = 0;

        /// <summary>
        /// 硼原子的数目
        /// </summary>
        public int N_B { get; set; } = 0;

        /// <summary>
        /// 金属原子的数目
        /// </summary>
        public int N_Met { get; set; } = 0;

        /// <summary>
        /// 除了以上列出的之外其他原子的数目。
        /// </summary>
        public int N_X { get; set; } = 0;

        /// <summary>
        /// 所有化学键的总数
        /// </summary>
        public int BondsCount { get; set; } = 0;

        /// <summary>
        /// 单键的个数
        /// </summary>
        public int N_b1 { get; set; } = 0;

        /// <summary>
        /// 不含氢的单键个数
        /// </summary>
        public int N_b1_NoH { get; set; } = 0;

        /// <summary>
        /// 双键的个数
        /// </summary>
        public int N_b2 { get; set; } = 0;

        /// <summary>
        /// 三键的个数
        /// </summary>
        public int N_b3 { get; set; } = 0;

        /// <summary>
        /// 芳香键的个数
        /// </summary>
        public int N_bar { get; set; } = 0;

        /// <summary>
        /// 碳-氧单键的个数
        /// </summary>
        public int N_C1O { get; set; } = 0;

        /// <summary>
        /// 碳=氧双键的个数
        /// </summary>
        public int N_C2O { get; set; } = 0;

        /// <summary>
        /// 任何类型的碳氮键的个数
        /// </summary>
        public int N_CN { get; set; } = 0;

        /// <summary>
        /// 任何类型的杂原子之间化学健的个数
        /// </summary>
        public int N_XY { get; set; } = 0;

        /// <summary>
        /// 所有环的总数
        /// </summary>
        public int RingsCount { get; set; } = 0;

        /// <summary>
        /// number of 3-membered rings 3元环个数
        /// </summary>
        public int N_r3 { get; set; } = 0;

        /// <summary>
        /// number of 4-membered rings 4元环个数
        /// </summary>
        public int N_r4 { get; set; } = 0;

        /// <summary>
        /// number of 5-membered rings 5元环个数
        /// </summary>
        public int N_r5 { get; set; } = 0;

        /// <summary>
        /// number of 6-membered rings 6元环个数
        /// </summary>
        public int N_r6 { get; set; } = 0;

        /// <summary>
        /// number of 7-membered rings 7元环个数
        /// </summary>
        public int N_r7 { get; set; } = 0;

        /// <summary>
        /// number of 8-membered rings 8元环个数
        /// </summary>
        public int N_r8 { get; set; } = 0;

        /// <summary>
        /// number of 9-membered rings 9元环个数
        /// </summary>
        public int N_r9 { get; set; } = 0;

        /// <summary>
        /// number of 10-membered rings 10元环个数
        /// </summary>
        public int N_r10 { get; set; } = 0;

        /// <summary>
        /// number of 11-membered rings 11元环个数
        /// </summary>
        public int N_r11 { get; set; } = 0;

        /// <summary>
        /// number of 12-membered rings 12元环个数
        /// </summary>
        public int N_r12 { get; set; } = 0;

        /// <summary>
        /// number of 13-membered or larger rings 13元环或者更大的环的个数
        /// </summary>
        public int N_r13p { get; set; } = 0;

        /// <summary>
        /// number of rings containing nitrogen (any number) 含氮环的个数
        /// </summary>
        public int N_rN { get; set; } = 0;

        /// <summary>
        /// number of rings containing 1 nitrogen atom 含一个氮原子的环的个数
        /// </summary>
        public int N_rN1 { get; set; } = 0;

        /// <summary>
        /// number of rings containing 2 nitrogen atoms 含两个个氮原子的环的个数
        /// </summary>
        public int N_rN2 { get; set; } = 0;

        /// <summary>
        /// number of rings containing 3 or more nitrogen atoms 含三个或以上个氮原子的环的个数
        /// </summary>
        public int N_rN3p { get; set; } = 0;

        /// <summary>
        /// number of rings containing oxygen (any number) 含氧环的个数
        /// </summary>
        public int N_rO { get; set; } = 0;

        /// <summary>
        /// number of rings containing 1 oxygen atom 含一个氧原子的环的个数
        /// </summary>
        public int N_rO1 { get; set; } = 0;

        /// <summary>
        /// number of rings containing 2 or more oxygen atoms 含三个或以上个氧原子的环的个数
        /// </summary>
        public int N_rO2p { get; set; } = 0;

        /// <summary>
        /// number of rings containing sulfur (any number) 含硫环的个数
        /// </summary>
        public int N_rS { get; set; } = 0;

        /// <summary>
        /// number of heterocycles (any type) 杂环的个数
        /// </summary>
        public int N_rX { get; set; } = 0;

        /// <summary>
        /// number of aromatic rings (any type) 芳香环的个数
        /// </summary>
        public int N_rar { get; set; } = 0;
    }
}
