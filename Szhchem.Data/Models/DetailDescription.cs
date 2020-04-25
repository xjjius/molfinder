using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szhchem.Data
{
    public class DetailDescription : Description
    {
        [BsonElement("CompanyIntId")]
        public int CompanyID { get; set; }
        public long SubstanceID { get; set; }
        public List<CompanyInfo> CompanyInformation { get; set; } = new List<CompanyInfo>();
    }
}
