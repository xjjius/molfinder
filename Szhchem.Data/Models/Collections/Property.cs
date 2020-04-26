using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PropertyId { get; set; }
        public long SubstanceID { get; set; }
        public long MolID { get; set; }
        public int LanguageCode { get; set; }
        public int PropertyCategory { get; set; }
        public int PropertyCode { get; set; }
        public string PropertyValue { get; set; }
        public string PropertyReference { get; set; }
    }    
}
