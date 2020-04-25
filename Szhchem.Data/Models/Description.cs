using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    /// <summary>
    /// 多语言描述文字
    /// </summary>
    public class Description
    {
        public int LanguageCode { get; set; }
        public string Title { get; set; }
        public string DetailText { get; set; }
        public string Url { get; set; }
    }
}