using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Szhchem.Data
{
    [Serializable]
    public class CalcProgram
    {
        /// <summary>
        /// 类别代码
        /// </summary>
        [XmlElement(ElementName = "Code")]
        public byte Code { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        
        /// <summary>
        /// 各种语言描述
        /// </summary>
        [XmlArray("Descriptions")]
        [XmlArrayItem(ElementName = "Description")]
        public List<DescriptionInfo> Descriptions { get; set; }
    }

    [XmlRoot("CalcProgramConfigInfo")]
    public class CalcProgramConfigInfo
    {
        public string _id { get; set; } = "CalcProgramConfigInfo";

        [XmlElement(ElementName = "CalcProgram")]
        public List<CalcProgram> CalcPrograms { get; set; }
    }
}
