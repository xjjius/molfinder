﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenBabel;

namespace Szhchem.Chemistry
{
    /// <summary>
    /// OpenBabel化学开发工具，包含分子结构分析以及相似度计算等功能
    /// </summary>
    public static class OpenBabelHelper
    {
        /// <summary>
        /// 从MolFile格式生成Openbabel的OBMol对象
        /// </summary>
        /// <param name="molfile">Mol文件格式的字符串</param>
        /// <returns>OBMol对象</returns>
        public static OBMol LoadMolFromMolfile(string molfile)
        {
            OBConversion conversion = new OBConversion();
            OBMol mol = new OBMol();
            conversion.SetInFormat("mol");
            conversion.ReadString(mol, molfile);
            return mol;
        }

        /// <summary>
        /// 从SMILES格式生成Openbabel的OBMol对象
        /// </summary>
        /// <param name="smiles">SMILES格式的字符串</param>
        /// <returns>OBMol对象</returns>
        public static OBMol LoadMolFromSmiles(string smiles)
        {
            OBConversion conversion = new OBConversion();
            OBMol mol = new OBMol();
            conversion.SetInFormat("smi");
            conversion.ReadString(mol, smiles);
            return mol;
        }

        /// <summary>
        /// SMILES格式转换成Mol文件格式
        /// </summary>
        /// <param name="smiles">SMILES</param>
        /// <returns>Mol</returns>
        public static string ConvertSmilesToMolFile(string smiles)
        {
            OBConversion conversion = new OBConversion();
            OBMol mol = new OBMol();
            conversion.SetInFormat("smi");
            conversion.ReadString(mol, smiles);
            conversion.SetOutFormat("mol");
            return conversion.WriteString(mol);
        }

        /// <summary>
        /// Mol文件格式转换成SMILES格式
        /// </summary>
        /// <param name="molFile">Mol</param>
        /// <returns>SMILES</returns>
        public static string ConvertMolFileToSmiles(string molFile)
        {
            OBConversion conversion = new OBConversion();
            OBMol mol = new OBMol();
            conversion.SetInFormat("mol");
            conversion.ReadString(mol, molFile);
            conversion.SetOutFormat("smi");
            return conversion.WriteString(mol);
        }

        /// <summary>
        /// 从选定官能团的位置数组转换成FP4. 
        /// selectedFGs数组中的每个数字代表该分子含有官能团表中这个数字所代表的官能团
        /// </summary>
        /// <param name="selectedFGs">含有的官能团编号，是个整数数组</param>
        /// <returns>Openbabel数据库格式的整数数组[16]</returns>
        public static List<long> GenerateFp4(List<int> selectedFGs)
        {
            OBConversion conv = new OBConversion(); //一定要有这句才不会报错            
            OBFingerprint fingerprint = OBFingerprint.FindFingerprint("FP4");
            VectorUInt fp4 = new VectorUInt(16);

            //初始化_fp4
            for (var i = 0; i < 16; i++)
            {
                fp4.Add(0);
            }

            foreach (var bit in selectedFGs)
            {
                fingerprint.SetBit(fp4, (uint)bit); //设置FP4
            }

            return fp4.Select(u => (long)u).ToList(); //
        }

        /// <summary>
        /// 从2D生成3D坐标，支持SMILES和Mol文件格式
        /// </summary>
        /// <param name="molString">Mol文件或者SMILES</param>
        /// <returns>含有3D坐标的Mol文件</returns>
        public static string Generate3D(string molString)
        {
            OBConversion conversion = new OBConversion();
            OBMol mol = new OBMol();

            if (molString.TrimEnd().EndsWith("M  END"))
            {
                conversion.SetInFormat("mol");
            }
            else if (!molString.Trim().Contains(" "))
            {
                conversion.SetInFormat("smi");
            }
            else
            {
                throw new Exception("Wrong chemical file format !!");
            }

            conversion.SetOutFormat("mol");

            conversion.ReadString(mol, molString);

            OBBuilder builder = new OBBuilder();
            builder.Build(mol);

            return conversion.WriteString(mol);
        }
    }
}
