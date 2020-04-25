using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Szhchem.Data;

namespace molfinder.Models
{
    public class MoleculeDataSource
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public long SubstanceID { get; set; }
        public long MolID { get; set; }
        public string ExtUrl { get; set; }
        public string ExtID { get; set; }
        public int DisplayOrder { get; set; }
        public int CompanyIntId { get; set; }
        public int DataSourceIntId { get; set; }
        public int UserRating { get; set; }
        public int Viewed { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<CompanyInfo> CompanyInformation { get; set; } = new List<CompanyInfo>();
        public List<DataSource> DataSources { get; set; } = new List<DataSource>();
        [BsonIgnore] public int DataSourceType;
    }
}