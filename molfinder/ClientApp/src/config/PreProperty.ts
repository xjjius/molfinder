import Description from "./Description";

class PreProperty {
    public code: number = 0;
    public name: string = "";
    public proCategory: number = 0;
    public isNullable: boolean = true;
    public isMultiRec: boolean = true;
    public dataType: string = "";
    public maxValue: number = 500;
    public descriptions: Array<Description> = new Array<Description>();

    constructor(code: number, name: string, proCategory: number, isNullable: boolean, isMultiRec: boolean, dataType: string, maxValue: number, descriptions: Array<Description>) {
        this.code = code;
        this.name = name;
        this.proCategory = proCategory;
        this.isNullable = isNullable;
        this.isMultiRec = isMultiRec;
        this.dataType = dataType;
        this.maxValue = maxValue;
        this.descriptions = descriptions;
    }
}

export default PreProperty;