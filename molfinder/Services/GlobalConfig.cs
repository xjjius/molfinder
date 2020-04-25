using Microsoft.Extensions.Options;
using Szhchem.Data;

namespace molfinder.Services
{
    public class GlobalConfig : SzhchemConfig
    {
        public readonly ConfigInfo ConfigInfo;
        public GlobalConfig(IOptions<DataOption> dataOption) 
            : base(dataOption.Value.ConnectionString, dataOption.Value.DatabaseName)
        {
            ConfigInfo = GetConfigInfo();
        }
    }
}