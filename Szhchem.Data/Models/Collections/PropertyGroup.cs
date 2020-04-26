using System.Collections.Generic;

namespace Szhchem.Data
{
    public class PropertyGroup
    {
        public int PropertyCategory { get; set; }
        public List<PropertyTypeGroup> Properties { get; set; } = new List<PropertyTypeGroup>();
    }
}