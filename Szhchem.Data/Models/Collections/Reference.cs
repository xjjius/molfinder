using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    public class Reference
    {
        [BsonId]
        public ObjectId ReferenceId { get; set; }
        public long MolID { get; set; }
        public long SubstanceID { get; set; }
        public int LanguageCode { get; set; }
        public int ReferenceSourceType { get; set; }
        public string ReferenceTitle { get; set; }
        public string ReferenceExtUrl { get; set; }
        public int Status { get; set; }
    }
}
