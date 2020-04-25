using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Szhchem.Data
{
    public class MolName
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MolNameId { get; set; }

        public long MolID { get; set; }
        public int NameType { get; set; }
        public int LanguageCode { get; set; }
        public string NameText { get; set; }
        public int Status { get; set; }
        [BsonIgnore] public List<long> SubstanceIDs { get; set; } = new List<long>();
    }

    public class MolNameComparer : IEqualityComparer<MolName>
    {
        public bool Equals(MolName x, MolName y)
        {
            return (x?.NameType == y?.NameType && x?.NameText == y?.NameText);
        }

        public int GetHashCode(MolName obj)
        {
            return obj.GetHashCode();
        }
    }
}