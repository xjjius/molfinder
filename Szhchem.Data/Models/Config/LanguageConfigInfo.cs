using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Szhchem.Data
{
    [XmlRoot("LanguageConfigInfo")]
    public class LanguageConfigInfo
    {
        public string _id { get; set; } = "LanguageConfigInfo";

        [XmlElement(ElementName = "Languages")]
        public List<Language> Languages { get; set; } = new List<Language>();
    }
    
    [Serializable]
    public class Language
    {
        public string ShortName { get; set; }        
        public int Code { get; set; }        
        public string Name { get; set; }
    }
}
