import Description from "./Description";

export default class DataSource {
    public dataSourceIntId: number;
    public dataSourceType: number;
    public dataSourceDescriptions: Array<Description>;
    public displayOrder: number;
    public dataSourceRating: number;
    public dataSourceTitle: string;
    public viewed: number;
    public timeCreated: Date;

    constructor(dataSourceIntId: number, dataSourceType: number, dataSourceDescriptions: Array<Description>, displayOrder: number, dataSourceRating: number, dataSourceTitle: string, viewed: number, timeCreated: Date) {
        this.dataSourceIntId = dataSourceIntId;
        this.dataSourceType = dataSourceType;
        this.dataSourceDescriptions = dataSourceDescriptions;
        this.displayOrder = displayOrder;
        this.dataSourceRating = dataSourceRating;
        this.dataSourceTitle = dataSourceTitle;
        this.viewed = viewed;
        this.timeCreated = timeCreated;
    }
}