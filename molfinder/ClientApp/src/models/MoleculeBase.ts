class MoleculeBase {
    public molFile: string;
    public isomericSmiles: string;
    public canonicSmiles: string;
    public exactMass: number;
    public mass: number;
    public formula: string;
    public charge: number;
    public inChI: string;
    public inChIKey: string;

    constructor(molFile: string, isomericSmiles: string, canonicSmiles: string, exactMass: number, mass: number, formula: string, charge: number, inChI: string, inChIKey: string) {
        this.molFile = molFile;
        this.isomericSmiles = isomericSmiles;
        this.canonicSmiles = canonicSmiles;
        this.exactMass = exactMass;
        this.mass = mass;
        this.formula = formula;
        this.charge = charge;
        this.inChI = inChI;
        this.inChIKey = inChIKey;
    }
}

export default MoleculeBase;