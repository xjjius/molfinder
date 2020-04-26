export default class MolName {
    public id: string;
    public molID: number;
    public nameType: number;
    public languageCode: number;
    public nameText: string;
    public status: number;

    constructor(id: string, molID: number, nameType: number, languageCode: number, nameText: string, status: number) {
        this.id = id;
        this.molID = molID;
        this.nameType = nameType;
        this.languageCode = languageCode;
        this.nameText = nameText;
        this.status = status;
    }
}