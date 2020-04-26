export default class Description {
    public languageCode: number;
    public title: string;
    public detailText: string;
    public url: string;

    constructor(languageCode: number, title: string, detailText: string, url: string) {
        this.languageCode = languageCode;
        this.title = title;
        this.detailText = detailText;
        this.url = url;
    }
}