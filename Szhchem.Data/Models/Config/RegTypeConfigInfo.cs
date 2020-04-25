using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Szhchem.Data
{
    [XmlRoot("RegTypeConfigInfo")]
    public class RegTypeConfigInfo
    {
        public string _id { get; set; } = "RegTypeConfigInfo";
        [XmlElement("RegType")]
        public List<RegType> RegTypes { get; set; } = new List<RegType>();
    }

    public class RegType
    {
        public int Code { get; set; }
        public string Name { get; set; }

        [XmlArray("Descriptions")]
        [XmlArrayItem(ElementName = "Description")]
        public List<DescriptionInfo> Descriptions { get; set; } = new List<DescriptionInfo>();
    }
}
