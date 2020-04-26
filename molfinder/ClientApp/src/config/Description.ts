class Description {
    public langCode: number = 0;
    public text: string = "ALL";

    constructor(langCode: number, text: string) {
        this.langCode = langCode;
        this.text = text;
    }
}
export default Description;
