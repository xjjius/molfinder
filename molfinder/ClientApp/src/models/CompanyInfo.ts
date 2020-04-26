import Address from "./Address";

export default class CompanyInfo {
    public languageCode: number;
    public shortName: string;
    public fullName: string;
    public comment: string;
    public address: Address;
    public email: string;
    public website: string;
    public phoneNumbers: Array<string>;
    public faxes: Array<string>;

    constructor(languageCode: number, shortName: string, fullName: string, comment: string, address: Address, email: string, website: string, phoneNumbers: Array<string>, faxes: Array<string>) {
        this.languageCode = languageCode;
        this.shortName = shortName;
        this.fullName = fullName;
        this.comment = comment;
        this.address = address;
        this.email = email;
        this.website = website;
        this.phoneNumbers = phoneNumbers;
        this.faxes = faxes;
    }
}