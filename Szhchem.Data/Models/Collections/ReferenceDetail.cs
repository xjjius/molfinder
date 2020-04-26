using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szhchem.Data
{
    public class ReferenceDetail : Reference
    {
        [BsonElement("CompanyIntId")]
        public int CompanyID { get; set; }
        public List<CompanyInfo> CompanyInformation { get; set; }
    }
}
