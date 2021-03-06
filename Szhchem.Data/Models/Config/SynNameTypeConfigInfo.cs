﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Szhchem.Data
{
    [XmlRoot("SynNameTypeConfigInfo")]
    public class SynNameTypeConfigInfo
    {
        public string _id { get; set; } = "SynNameTypeConfigInfo";
        [XmlElement("SynNameType")]
        public List<SynNameType> SynNameTypes { get; set; } = new List<SynNameType>();
    }

    public class SynNameType
    {
        public int Code { get; set; }
        public string Name { get; set; }

        [XmlArray("Descriptions")]
        [XmlArrayItem(ElementName = "Description")]
        public List<DescriptionInfo> Descriptions { get; set; } = new List<DescriptionInfo>();
    }
}
