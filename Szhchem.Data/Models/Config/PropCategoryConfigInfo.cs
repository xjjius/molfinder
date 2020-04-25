using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Szhchem.Data
{
    [XmlRoot("PropCategoryConfigInfo")]
    public class PropCategoryConfigInfo
    {
        public string _id { get; set; } = "PropCategoryConfigInfo";
        [XmlElement("PropCategory")]
        public List<PropCategory> PropCategory { get; set; } = new List<PropCategory>();
    }

    public class PropCategory
    {
        public int Code { get; set; }
        public string Name { get; set; }

        [XmlArray("Descriptions")]
        [XmlArrayItem(ElementName = "Description")]
        public List<DescriptionInfo> Descriptions { get; set; } = new List<DescriptionInfo>();
    }
}
