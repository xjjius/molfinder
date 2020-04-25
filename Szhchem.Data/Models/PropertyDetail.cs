using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szhchem.Data
{
    public class PropertyDetail : Property
    {
        [BsonElement("CompanyIntId")]
        public int CompanyID { get; set; }
        public List<CompanyInfo> CompanyInformation { get; set; } = new List<CompanyInfo>();
        public List<Description> SubstanceDetails { get; set; } = new List<Description>();
    }
}
