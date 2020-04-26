import Description from "./Description";
import Languages from "./Languages";
import intl from "react-intl-universal";
import PreProperty from "./PreProperty";
import CalcProgram from "./CalcProgram";
import PropCategory from "./PropCategory";
import Property from "../models/Property";
import Config from "./Config";
import SynNameType from "./SynNameType";
import RegType from "./RegType";
import nfpa_imgage from "./NFPA_704.svg"


class Labels {
    private static instance: Labels = new Labels();
    private readonly languages = new Languages();
    config: Config | undefined;

    private constructor() {
        if (Labels.instance) {
            throw new Error("Error - use Singleton.getInstance()");
        }
        console.log("First time...");
    }

    static getInstance(): Labels {
        if (!this.instance) {
            this.instance = new Labels();
        } else {
            console.log('lazy loading singleton has created');
        }
        return this.instance;
    }

    private getDescriptionText(descriptions: Array<Description> | undefined): string | undefined {
        let langCode: number = this.getCurrentLanguageCode();
        let ret = descriptions?.find((value: Description) => value.langCode === langCode);
        return ret?.text;
    }

    getCurrentLanguageCode(): number {
        return this.languages.getLangCodeByLocaleText(intl.getInitOptions().currentLocale);
    }

    getPropertyDescriptionByCode(code: number): string | undefined {
        if (this.config?.preProperties.length === 0) {
            return "Property #" + code;
        } else {
            //console.log(this.config.preProperty);
            let preProp: PreProperty | undefined = this.config?.preProperties
                .find((p) => p.code === code);
            return this.getDescriptionText(preProp?.descriptions);
        }
    }

    getProgramNameByCode(code: number): string | undefined {
        if (this.config?.calcPrograms.length === 0) {
            return "Program #" + code;
        } else {
            let calcProgram: CalcProgram | undefined = this.config?.calcPrograms
                .find((p) => p.code === code);
            return this.getDescriptionText(calcProgram?.descriptions);
        }
    }

    getPropCategoryByCode(code: number): string | undefined {
        if (this.config?.preProperties.length === 0) {
            return "PropCategory #" + code;
        } else {
            let propCategory: PropCategory | undefined = this.config?.propCategories
                .find((p) => p.code === code);
            return this.getDescriptionText(propCategory?.descriptions);
        }
    }

    getSynNameTypeByCode(code: number): string | undefined {
        if (this.config?.synNameTypes.length === 0) {
            return "SynNameTypes #" + code;
        } else {
            let synNameType: SynNameType | undefined = this.config?.synNameTypes
                .find((p) => p.code === code);
            return this.getDescriptionText(synNameType?.descriptions);
        }
    }

    getRegTypeByCode(code: number): string | undefined {
        if (this.config?.regTypes.length === 0) {
            return "RegTypes #" + code;
        } else {
            let regType: RegType | undefined = this.config?.regTypes
                .find((p) => p.code === code);
            return this.getDescriptionText(regType?.descriptions);
        }
    }

    getRegUrlByRegNo(regNo: string, regTypeCode: number): string | undefined {
        if (this.config?.regUrls.length === 0) {
            return `${0}`;
        } else {
            let format = this.config?.regUrls
                .find(r => r.code === regTypeCode)?.urlPatterns
                .find(u => u.langCode === labels.getCurrentLanguageCode())?.formatString;
            return format?.replace('{0}', regNo);
        }
    }

    displayPropertyByValue(propertyValue: string, propertyCode: number): string {
        if (propertyValue.startsWith("http://") || propertyValue.startsWith("https://")) {
            return `<a href="${propertyValue}" target="_blank">Download link</a>`;
        } else if (propertyCode === 141) {
            return this.GetNFPASign(propertyValue);
        } else {
            return propertyValue;
        }
    }

    displayProperty(property: Property): string {
        return this.displayPropertyByValue(property.propertyValue, property.propertyCode);
    }

    convertSubscripts(formula: string): string {
        let subs: Array<string> = new Array<string>("₀", "₁", "₂", "₃", "₄", "₅", "₆", "₇", "₈", "₉");
        let result: string = formula;
        for (let i: number = 0; i < 10; i++) {
            let regStr: string = '/' + i + "/g";
            // eslint-disable-next-line no-eval
            let regex: RegExp = eval(regStr);
            result = result.replace(regex, subs[i]);
        }
        return result;
    }

    private GetNFPASign(nfpaCode: string): string {
        let nfpa: Array<string> = nfpaCode.split('/');
        let h: string = "";
        let f: string = "";
        let r: string = "";
        let o: string = "";
        console.log(nfpa);
        nfpa.forEach(n => {
            console.log(n);
            let _tmp = n.substring(0, 1);

            console.log(_tmp);
            let _code = n.substring(1);
            console.log(_code);
            switch (_tmp) {
                case "H":
                    h = _code;
                    break;
                case "F":
                    f = _code;
                    break;
                case "R":
                    r = _code;
                    break;
                case "O":
                    o = _code;
                    break;
            }
        });

        let result = `
            <div style="position: relative; height: 85px; width: 75px; margin-top: 5px; margin-bottom: -5px;">
                <div style="position: absolute; height: 75px; width: 75px;">
                    <img src="${nfpa_imgage}" width="75px" height="75px" alt="NFPA 704 diagram"/>
                </div>
                <div title="Flammability" style="background:transparent; width:75px; height:2em; text-align:center; vertical-align:middle; position:absolute; top:4px; font-size:large; color:black;">
                    <b>${f}</b>
                </div>
                <div title="Health" style="background: transparent; width: 37.5px; height: 2em; text-align: center; vertical-align: middle; position: absolute; top: 23px; font-size: large; color:black;">
                    <b>${h}</b>
                </div>
                <div title="Reactivity" style="background: transparent; width: 37.5px; height: 2em; text-align: center; vertical-align: middle; position: absolute; top: 23px; left: 37.5px; font-size: large; color:black;">
                    <b>${r}</b>
                </div>
                <div title="Other hazards" style="background: transparent; width: 75px; height: 2em; text-align: center; vertical-align: middle; position: absolute; top: 43px; font-size: small; color:black;">
                    <b>${o}</b>
                </div>
            </div>
        `;

        return result;
    }
}

const labels: Labels = Labels.getInstance();

export default labels;