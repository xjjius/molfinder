using com.epam.indigo;

namespace Szhchem.Chemistry
{
    public class IndigoBase
    {
        protected readonly Indigo indigo = new Indigo();
        protected IndigoRenderer renderer;

        public IndigoBase()
        {
            renderer = new IndigoRenderer(indigo);
            indigo.setOption("ignore-stereochemistry-errors", true);
            indigo.setOption("render-output-format", "png");
            indigo.setOption("render-margins", 20, 20);
            //indigo.setOption("render-image-max-width", 500);
            //indigo.setOption("render-image-max-height", 250);
            indigo.setOption("render-coloring", true);
            indigo.setOption("render-stereo-style", "none");
        }

        public byte[] RenderMolStringToBuffer(string molString)
        {
            var mol = indigo.loadMolecule(molString);
            mol.layout();
            return renderer.renderToBuffer(mol);
        }
    }
}