using System.Globalization;
using System.Linq;

namespace Szhchem.Data
{
    public class SzhchemConfig
    {
        private CalcProgramConfigInfo CalcProgramInfo { get; set; }
        private LanguageConfigInfo LanguageInfo { get; set; }
        private PrePropertyConfigInfo PropertyInfo { get; set; }
        private RegTypeConfigInfo RegTypeInfo { get; set; }
        private SynNameTypeConfigInfo SynNameTypeInfo { get; set; }
        private RegUrlPatterns RegUrlPatterns { get; set; }
        private PropCategoryConfigInfo PropCategoryInfo { get; set; }
        private DataSourceTypeConfigInfo DataSourceTypeInfo { get; set; }
        private int CurrentLangCode { get; set; }
        
        public string[] PropertyTags { get; set; } = {"PROPERTY", "SAFETY", "PHARMACOLOGY", "DESCRIPTOR"};

        public SzhchemConfig(string connectionString, string databaseName)
        {
            var db = new MongoDbContext(connectionString, databaseName);
            CalcProgramInfo = db.ReadConfigData<CalcProgramConfigInfo>();
            LanguageInfo = db.ReadConfigData<LanguageConfigInfo>();
            PropertyInfo = db.ReadConfigData<PrePropertyConfigInfo>();
            RegTypeInfo = db.ReadConfigData<RegTypeConfigInfo>();
            SynNameTypeInfo = db.ReadConfigData<SynNameTypeConfigInfo>();
            DataSourceTypeInfo = db.ReadConfigData<DataSourceTypeConfigInfo>();
            PropCategoryInfo = db.ReadConfigData<PropCategoryConfigInfo>();
            RegUrlPatterns = db.ReadConfigData<RegUrlPatterns>();
            string currentLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToUpper();
            CurrentLangCode = LanguageInfo.Languages.First(t => t.ShortName == currentLanguage).Code;
        }

        public ConfigInfo GetConfigInfo()
        {
            var config = new ConfigInfo
            {
                CalcPrograms = CalcProgramInfo.CalcPrograms,
                PreProperties = PropertyInfo.PreProperty,
                PropCategories = PropCategoryInfo.PropCategory,
                SynNameTypes = SynNameTypeInfo.SynNameTypes,
                RegTypes = RegTypeInfo.RegTypes,
                RegUrls = RegUrlPatterns.RegUrls
            };

            return config;
        }
    }
}