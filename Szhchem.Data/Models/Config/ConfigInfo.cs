using System.Collections.Generic;

namespace Szhchem.Data
{
    public class ConfigInfo
    {
        public List<CalcProgram> CalcPrograms { get; set; } = new List<CalcProgram>();
        public List<PreProperty> Properties { get; set; } = new List<PreProperty>();
        public List<PropCategory> PropCategories { get; set; } = new List<PropCategory>();
        public List<SynNameType> SynNameTypes { get; set; } = new List<SynNameType>();
        public List<RegType> RegTypes { get; set; } = new List<RegType>();
        public List<RegUrl> RegUrls { get; set; } = new List<RegUrl>();
    }
}