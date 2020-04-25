using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    public class MolRegNo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MolRegNoId { get; set; }

        public long MolID { get; set; }
        public int RegType { get; set; }
        public string RegNoValue { get; set; }
        public string RegNoUrl { get; set; }
        public int Status { get; set; }
        [BsonIgnore] public List<long> SubstanceIDs = new List<long>();
    }
}