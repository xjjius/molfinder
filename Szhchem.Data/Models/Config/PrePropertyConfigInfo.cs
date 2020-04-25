using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Szhchem.Data
{
    public class PreProperty
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int PropCategory { get; set; }
        public bool IsNullable { get; set; }
        public bool IsMultiRec { get; set; }
        public string DataType { get; set; }
        public bool IsMultiLang { get; set; }
        public int MaxValue { get; set; }

        [XmlArray("Descriptions")]
        [XmlArrayItem(ElementName = "Description")]
        public List<DescriptionInfo> Descriptions { get; set; } = new List<DescriptionInfo>();
    }

    [XmlRoot("PrePropertyConfigInfo")]
    public class PrePropertyConfigInfo
    {
        public string _id { get; set; } = "PrePropertyConfigInfo";

        [XmlElement(ElementName = "PreProperty")]
        public List<PreProperty> PreProperty { get; set; }
    }
}
