using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szhchem.Data
{
    public class SequenceId
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string collection { get; set; }
        public string idField { get; set; }
        public long seq { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
