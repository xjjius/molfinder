using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using Szhchem.Chemistry;

namespace Szhchem.Data
{
    public class Molecule : MoleculeBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public long MolID { get; set; }
        public string MolGuid { get; set; }
        public List<CalculatedProperty> CalculatedProperties { get; set; } = new List<CalculatedProperty>();        
        //public List<ObjectId> NameIDs { get; set; } = new List<ObjectId>();
        //public List<ObjectId> RegNoIDs { get; set; } = new List<ObjectId>();
        //public List<ObjectId> PropertyIDs { get; set; } = new List<ObjectId>();
        public DateTime TimeCreated { get; set; }
        [BsonIgnore]
        public double Similarity { get; set; }
        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public int DiffSum { get; set; }        
    }

    public class MoleculeComparer : IEqualityComparer<Molecule>
    {
        public bool Equals(Molecule x, Molecule y)
        {         
            return x?.MolID == y?.MolID;
        }

        public int GetHashCode(Molecule obj)
        {
            return obj.GetHashCode();
        }
    }
}
