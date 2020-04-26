export default class CalculatedProperty {
    public propertyCode: number;
    public programCode: number;
    public propertyText: string;
    public propertyMolID: bigint;

    constructor(propertyCode: number, programCode: number, propertyText: string, propertyMolID: bigint) {
        this.propertyCode = propertyCode;
        this.programCode = programCode;
        this.propertyText = propertyText;
        this.propertyMolID = propertyMolID;
    }
}