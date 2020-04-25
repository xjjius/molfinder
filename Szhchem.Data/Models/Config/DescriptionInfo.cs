using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;

namespace Szhchem.Data
{
    /// <summary>
    /// 语言描述信息
    /// </summary>
    [Serializable]
    public class DescriptionInfo
    {
        /// <summary>
        /// 语言代码
        /// </summary>
        [XmlElement(ElementName = "LangCode")]
        public byte LangCode { get; set; } = 0;
        /// <summary>
        /// 对应语言的描述
        /// </summary>
        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }
    }
}
