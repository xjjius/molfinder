using System.Collections.Generic;

namespace Szhchem.Data
{
    public class PropertyTypeGroup
    {
        public int PropertyCode { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}