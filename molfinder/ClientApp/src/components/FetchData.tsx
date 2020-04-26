import React, {Component} from 'react';
import intl from "react-intl-universal";
import {ConfigInfo} from "./ConfigInfo";

export class FetchData extends Component {
    static displayName = FetchData.name;
    render() {
        return (
            <ConfigInfo url="/api/config" locale = {intl.getInitOptions().currentLocale}/>
        );
    }
}