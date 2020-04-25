using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    public class DataSource
    {        
        public int DataSourceIntId { get; set; }
        public int DataSourceType { get; set; }
        public List<Description> DataSourceDescriptions { get; set; }
        public int DisplayOrder { get; set; }
        public int DataSourceRating { get; set; }
        public string DataSourceTitle { get; set; }
        public int Viewed { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
