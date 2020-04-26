import MoleculeBase from "./MoleculeBase";
import CalculatedProperty from "./CalculatedProperty";

export default class Molecule extends MoleculeBase {
    public calculatedProperties: Array<CalculatedProperty> = new Array<CalculatedProperty>();
    public timeCreated: Date;
    //public MolStat molStat = new MolStat();
    public fp4: Array<number> = new Array<number>(16);
    public fp2: Array<number> = new Array<number>(32);


    constructor(molFile: string, isomericSmiles: string, canonicSmiles: string, exactMass: number, mass: number, formula: string, charge: number, inChI: string, inChIKey: string, calculatedProperties: Array<CalculatedProperty>, timeCreated: Date, fp4: Array<number>, fp2: Array<number>) {
        super(molFile, isomericSmiles, canonicSmiles, exactMass, mass, formula, charge, inChI, inChIKey);
        this.calculatedProperties = calculatedProperties;
        this.timeCreated = timeCreated;
        this.fp4 = fp4;
        this.fp2 = fp2;
    }
}