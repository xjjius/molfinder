import Company from "./Company";

export default class SubstanceSupplier {
    public company: Company;
    public substanceID: number;
    public extUrl: string;
    public extID: string;

    constructor(company: Company, substanceID: number, extUrl: string, extID: string) {
        this.company = company;
        this.substanceID = substanceID;
        this.extUrl = extUrl;
        this.extID = extID;
    }
}