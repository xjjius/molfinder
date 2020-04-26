import CompanyInfo from "./CompanyInfo";
import DataSource from "./DataSource";
import Contact from "./Contact";

export default class Company {
    public companyId: string;
    public companyIntId: number;
    public companyRating: number;
    public companyInformation: Array<CompanyInfo>;
    public dataSources: Array<DataSource>;
    public contacts:Array<Contact>;
    public timeCreated: Date;

    constructor(companyId: string, companyIntId: number, companyRating: number, companyInformation: Array<CompanyInfo>, dataSources: Array<DataSource>, contacts: Array<Contact>, timeCreated: Date) {
        this.companyId = companyId;
        this.companyIntId = companyIntId;
        this.companyRating = companyRating;
        this.companyInformation = companyInformation;
        this.dataSources = dataSources;
        this.contacts = contacts;
        this.timeCreated = timeCreated;
    }
}