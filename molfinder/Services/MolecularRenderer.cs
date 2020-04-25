using Szhchem.Chemistry;

namespace molfinder.Services
{
    public class MolecularRenderer
    {
        public string RenderToDataUrl(string molFile)
        {
            return IndigoHelper.RenderToDataUrl(molFile);
        }
    }
}