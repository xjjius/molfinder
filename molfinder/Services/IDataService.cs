using System.Collections;
using System.Collections.Generic;
using molfinder.Models;
using Szhchem.Data;

namespace molfinder.Services
{
    public interface IDataService
    {
        Company GetCompanyByCompanyId(int companyID);
        Molecule GetOneMoleculeByMolId(long molID);
        IEnumerable<MoleculeDataSource> GetMoleculeDataSources(long molID);
        IEnumerable<SubstanceSupplier> GetSuppliersInfo(IEnumerable<long> substanceIDs);
        IEnumerable<PropertyGroup> GetMoleculeProperty(long molID);
        IEnumerable<MolNameGroup> GetMolNamesByMolID(long molID);
        IEnumerable<MolRegNoGroup> GetMolRegNoByMolID(long molID);
    }
}