export default class UrlPattern {
    public langCode: number;
    public formatString: string;

    constructor(langCode: number, formatString: string) {
        this.langCode = langCode;
        this.formatString = formatString;
    }
}