using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    public class CalculatedProperty
    {
        [BsonIgnore]
        public long PropertyMolID { get; set; }
        public int ProgramCode { get; set; }
        public int PropertyCode { get; set; }
        public string PropertyText { get; set; }
    }
}
