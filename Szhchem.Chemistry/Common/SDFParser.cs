﻿using OpenBabel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Szhchem.Chemistry
{
    public class SDFParser
    {
        /// <summary>
        /// 读取SDF文件中的内容，并赋值给List<SDFSection>对象。该功能通过Openbabel开源项目实现
        /// </summary>
        /// <param name="fileName">SDF文件名</param>
        /// <returns></returns>
        public static List<SDFSection> ReadSDF(string fileName)
        {
            List<SDFSection> result = new List<SDFSection>();

            OBConversion conv = new OBConversion();
            OBMol mol = new OBMol();
            conv.SetInFormat("sdf");
            conv.ReadFile(mol, fileName);            
            
            do //遍历SDF文件并赋值
            {
                SDFSection section = new SDFSection();
                conv.SetOutFormat("mol");
                section.MolFile = conv.WriteString(mol);
                var data = mol.GetAllData(1);
                foreach (var d in data)
                {
                    if (d.GetOrigin().ToString() == "fileformatInput")
                        section.Properties.Add(new SDFProperty
                        {
                            Name = d.GetAttribute(),
                            Value = d.GetValue(),
                        });
                }
                result.Add(section);
            } while (conv.Read(mol));

            return result;
        }
    }
}
