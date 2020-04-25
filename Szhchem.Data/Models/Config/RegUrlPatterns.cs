using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Szhchem.Data
{
    [XmlRoot("RegUrlPatterns")]
    public class RegUrlPatterns
    {
        public string _id { get; set; } = "RegUrlPatterns";

        [XmlElement("RegType")]
        public List<RegUrl> RegUrls { get; set; } = new List<RegUrl>();
    }

    public class RegUrl
    {
        public int Code { get; set; }
        public string Name { get; set; }

        [XmlArray("UrlPatterns")]
        [XmlArrayItem(ElementName = "Pattern")]
        public List<UrlPattern> UrlPatterns { get; set; }
    }

    public class UrlPattern
    {
        public int LangCode { get; set; }
        public string FormatString { get; set; }
    }
}
