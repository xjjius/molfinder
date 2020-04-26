import PreProperty from "./PreProperty";
import CalcProgram from "./CalcProgram";
import PropCategory from "./PropCategory";
import SynNameType from "./SynNameType";
import RegType from "./RegType";
import RegUrl from "./RegUrl";

export default class Config {
    public preProperties: Array<PreProperty> = new Array<PreProperty>();
    public calcPrograms: Array<CalcProgram>= new Array<CalcProgram>();
    public propCategories: Array<PropCategory> = new Array<PropCategory>();
    public synNameTypes: Array<SynNameType> = new Array<SynNameType>();
    public regTypes: Array<RegType> = new Array<RegType>();
    public regUrls: Array<RegUrl> = new Array<RegUrl>();
}