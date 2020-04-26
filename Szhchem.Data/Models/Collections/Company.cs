using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CompanyId { get; set; }

        public int CompanyIntId { get; set; }
        public int CompanyRating { get; set; }
        public List<CompanyInfo> CompanyInformation { get; set; } = new List<CompanyInfo>();
        public List<DataSource> DataSources { get; set; } = new List<DataSource>();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public DateTime TimeCreated { get; set; }
    }

    public class CompanyInfo
    {
        public int LanguageCode { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Comment { get; set; }
        public Address Adress { get; set; } = new Address();
        public string Email { get; set; }
        public string Website { get; set; }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public List<string> Faxes { get; set; } = new List<string>();
    }
}