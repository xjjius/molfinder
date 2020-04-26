export default class Property {
    public id: string;
    public substanceID: number;
    public molID: number;
    public languageCode: number;
    public propertyCategory: number;
    public propertyCode: number;
    public propertyValue: string;
    public propertyReference: string;

    constructor(id: string, substanceID: number, molID: number, languageCode: number, propertyCategory: number, propertyCode: number, propertyValue: string, propertyReference: string) {
        this.id = id;
        this.substanceID = substanceID;
        this.molID = molID;
        this.languageCode = languageCode;
        this.propertyCategory = propertyCategory;
        this.propertyCode = propertyCode;
        this.propertyValue = propertyValue;
        this.propertyReference = propertyReference;
    }
}