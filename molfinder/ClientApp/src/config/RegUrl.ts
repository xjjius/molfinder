import UrlPattern from "./UrlPattern";

export default class RegUrl {
    public code: number;
    public name: string;
    public urlPatterns: Array<UrlPattern> = new Array<UrlPattern>();

    constructor(code: number, name: string, urlPatterns: Array<UrlPattern>) {
        this.code = code;
        this.name = name;
        this.urlPatterns = urlPatterns;
    }
}