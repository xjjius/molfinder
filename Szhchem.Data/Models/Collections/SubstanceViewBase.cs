using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szhchem.Data
{
    public class SubstanceViewBase : Substance
    {
        [BsonIgnore]
        public int DataSourceType { get; set; }
        public List<CompanyInfo> CompanyInformation { get; set; } = new List<CompanyInfo>();
        public List<DataSource> DataSources { get; set; } = new List<DataSource>();
        public SubstanceViewBase() : base() { }
        public SubstanceViewBase(Substance substance)
        {
            SubstanceID = substance.SubstanceID;
            MolID = substance.MolID;
            ExtID = substance.ExtID;
            DisplayOrder = substance.DisplayOrder;
            CompanyIntId = substance.CompanyIntId;
            DataSourceIntId = substance.DataSourceIntId;
            UserRating = substance.UserRating;
            Viewed = substance.Viewed;
        }
    }
}
