import CompanyInfo from "./CompanyInfo";
import DataSource from "./DataSource";

export default class MoleculeDataSource {
    public id: string;
    public substanceID: number;
    public molID: number;
    public extUrl: string;
    public extID: string;
    public displayOrder: number;
    public companyIntId: number;
    public dataSourceIntId: number;
    public userRating: number;
    public viewed: number;
    public timeCreated: Date;
    public companyInformation: Array<CompanyInfo> = new Array<CompanyInfo>();
    public dataSources: Array<DataSource> = new Array<DataSource>();
    public dataSourceType: number;

    constructor(id: string, substanceID: number, molID: number, extUrl: string, extID: string, displayOrder: number, companyIntId: number, dataSourceIntId: number, userRating: number, viewed: number, timeCreated: Date, companyInformation: Array<CompanyInfo>, dataSources: Array<DataSource>, dataSourceType: number) {
        this.id = id;
        this.substanceID = substanceID;
        this.molID = molID;
        this.extUrl = extUrl;
        this.extID = extID;
        this.displayOrder = displayOrder;
        this.companyIntId = companyIntId;
        this.dataSourceIntId = dataSourceIntId;
        this.userRating = userRating;
        this.viewed = viewed;
        this.timeCreated = timeCreated;
        this.companyInformation = companyInformation;
        this.dataSources = dataSources;
        this.dataSourceType = dataSourceType;
    }
}