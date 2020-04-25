using System;
using System.Collections.Generic;
using System.Text;

namespace Szhchem.Data
{
    public class DataSourceTypeConfigInfo
    {
        public string _id { get; set; } = "DataSourceTypeConfigInfo";
        public List<DataSourceType> DataSourceTypes { get; set; } = new List<DataSourceType>();
    }

    public class DataSourceType
    {
        public byte Code { get; set; }
        public List<DescriptionInfo> Descriptions { get; set; }
    }
}
