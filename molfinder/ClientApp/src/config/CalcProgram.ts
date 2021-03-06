import Description from "./Description";

class CalcProgram {
    public code: number;
    public name: string;
    public descriptions: Array<Description> = new Array<Description>();

    constructor(code: number, name: string, descriptions: Array<Description>) {
        this.code = code;
        this.name = name;
        this.descriptions = descriptions;
    }
}

export default CalcProgram;