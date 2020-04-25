using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Szhchem.Data
{
    public class Substance
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public long SubstanceID { get; set; }
        public long MolID { get; set; }
        public string ExtUrl { get; set; }
        public string ExtID { get; set; }
        public int? DisplayOrder { get; set; }
        public List<ObjectId> NameIDs { get; set; } = new List<ObjectId>();
        public List<ObjectId> RegNoIDs { get; set; } = new List<ObjectId>();
        //public List<ObjectId> SubstancePropertyIds { get; set; } = new List<ObjectId>();
        public List<Description> SubstanceDetails { get; set; } = new List<Description>();
        public List<Price> Prices { get; set; } = new List<Price>();
        public List<ObjectId> ReferenceIDs { get; set; } = new List<ObjectId>();
        public int CompanyIntId { get; set; }
        public int DataSourceIntId { get; set; }
        public int UserRating { get; set; }
        public int Viewed { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
