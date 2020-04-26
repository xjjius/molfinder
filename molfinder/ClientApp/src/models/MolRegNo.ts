export default class MolRegNo {
    public molRegNoId: string;
    public molID: number;
    public regType: number;
    public regNoValue: string;
    public regNoUrl: string;
    public status: number;

    constructor(molRegNoId: string, molID: number, regType: number, regNoValue: string, regNoUrl: string, status: number) {
        this.molRegNoId = molRegNoId;
        this.molID = molID;
        this.regType = regType;
        this.regNoValue = regNoValue;
        this.regNoUrl = regNoUrl;
        this.status = status;
    }
}