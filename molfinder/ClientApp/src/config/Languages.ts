export default class Languages {
    public languages: Array<Language> = new Array<Language>();

    constructor() {
        this.languages = [
            {
                shortName: "EN",
                code: 1,
                name: "English"
            },
            {
                shortName: "ZH",
                code: 2,
                name: "简体中文"
            }
        ];
    }

    public getLangCodeByLocaleText(localeText: string | undefined): number {
        let ret = this.languages.find(value => value.shortName.toLowerCase() === localeText);
        return ret == null ? 0 : ret.code;
    }
}

class Language {
    public shortName: string = "";
    public code: number = 0;
    public name: string = "";

    constructor(shortName: string, code: number, name: string) {
        this.shortName = shortName;
        this.code = code;
        this.name = name;
    }
}