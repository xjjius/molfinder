using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using molfinder.Models;
using molfinder.Services;
using Szhchem.Chemistry;
using Szhchem.Data;

namespace molfinder.Controllers
{
    [EnableCors()]
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly GlobalConfig _global;
        private readonly IDataService _data;
        private readonly MolecularRenderer _renderer;
        
        public ApiController(GlobalConfig globalConfig, IDataService dataService, MolecularRenderer renderer)
        {
            _global = globalConfig;
            _data = dataService;
            _renderer = renderer;
        }
        
        [Route("molimg")]
        [HttpPost]
        public string GetMoleculeImg(MoleculeBase molBase)
        {
            return _renderer.RenderToDataUrl(molBase.MolFile);
        }

        [Route("molecule")]
        public Molecule GetMolecule(long molId)
        {
            return _data.GetOneMoleculeByMolId(molId);;
        }
        
        [Route("company")]
        public Company GetCompany(int companyId)
        {
            return _data.GetCompanyByCompanyId(companyId);
        }

        [Route("config")]
        public ConfigInfo GetConfig()
        {
            return _global.ConfigInfo;
        }

        [Route("moleculeDataSource")]
        public IEnumerable<MoleculeDataSource> GetMoleculeDataSources(long molId)
        {
            return _data.GetMoleculeDataSources(molId);
        }

        [Route("suppliers")]
        [HttpPost]
        public IEnumerable<SubstanceSupplier> GetSuppliers(long[] substanceIDs)
        {
            return _data.GetSuppliersInfo(substanceIDs);
        }

        [Route("moleculeProperty")]
        public IEnumerable<PropertyGroup> GetMoleculeProperties(long molID)
        {
            return _data.GetMoleculeProperty(molID);
        }

        [Route("molnames")]
        public IEnumerable<MolNameGroup> GetMolNameGroupFromMolID(long molID)
        {
            return _data.GetMolNamesByMolID(molID);
        }

        [Route("molregnos")]
        public IEnumerable<MolRegNoGroup> GetMolRegNoGroupFromMolID(long molID)
        {
            return _data.GetMolRegNoByMolID(molID);
        }
    }
}