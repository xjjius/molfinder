using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szhchem.Data
{
    public class Contact
    {
        public List<ContactInfo> ContactInfo { get; set; } = new List<ContactInfo>();
        public string NickName { get; set; }
        public DateTime TimeCreated { get; set; }
    }

    public class ContactInfo
    {
        public int LanguageCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email;
        public Address ContactAddress { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Memo { get; set; }
    }
}