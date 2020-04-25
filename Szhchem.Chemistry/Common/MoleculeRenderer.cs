using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using com.epam.indigo;

namespace Szhchem.Chemistry
{
    public class MoleculeRenderer : IndigoBase
    {
        public byte[] RenderToBuffer(string molString)
        {
            return RenderMolStringToBuffer(molString);
        }

        public byte[] RenderHighlightedSmartsPattern(string molString, string smarts)
        {
            var mol = indigo.loadMolecule(molString);
            var query = indigo.loadSmarts(smarts);
            query.optimize();
            return RenderHighlightedObject(mol, query);
        }
        
        public byte[] RenderHighlightedSubstructure(string molString, string highlight)
        {
            var mol = indigo.loadMolecule(molString);
            var query = indigo.loadQueryMolecule(highlight);
            return RenderHighlightedObject(mol, query);
        }
        
        private byte[] RenderHighlightedObject(IndigoObject mol, IndigoObject query)
        {
            query.aromatize();
            IndigoObject matcher = indigo.substructureMatcher(mol);

            foreach (IndigoObject match in matcher.iterateMatches(query))
            {
                foreach (IndigoObject queryAtom in query.iterateAtoms())
                {
                    IndigoObject atom = match.mapAtom(queryAtom);
                    atom.highlight();

                    foreach (IndigoObject nei in atom.iterateNeighbors())
                    {
                        if (!nei.isPseudoatom() && !nei.isRSite() && nei.atomicNumber() == 1)
                        {
                            nei.highlight();
                            nei.bond().highlight();
                        }
                    }
                }

                foreach (IndigoObject bond in query.iterateBonds())
                {
                    match.mapBond(bond).highlight();
                }
            }

            indigo.setOption("render-coloring", false);
            mol.dearomatize();
            mol.layout();
            return renderer.renderToBuffer(mol);
        }
    }
}